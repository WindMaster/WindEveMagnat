using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindEveMagnat.Common
{
	public class JsonFile<T>
	{
		public string FileName { get; set; }
		public string ErrorMessage { get; set; }
		private string _jsonFileContent;
		private T _internalObject;

		public bool OpenAndRead()
		{
			if (string.IsNullOrEmpty(FileName))
			{
				ErrorMessage = "File name is not set";
				return false;
			}

			try
			{
				_jsonFileContent = File.ReadAllText(FileName);
			}
			catch (FileNotFoundException exception)
			{
				ErrorMessage = exception.Message;
				return false;
			}
			if( string.IsNullOrEmpty( _jsonFileContent ) )
			{
				File.Delete(FileName);
				return false;
			}

			_internalObject = JsonConvert.DeserializeObject<T>(_jsonFileContent);

			if( _internalObject == null )
			{
				File.Delete(FileName);
				return false;
			}

			return true;
		}

		public void OpenAndWrite()
		{
			if(File.Exists(FileName))
				File.Delete(FileName);

			var fl = File.CreateText(FileName);
			var stream = JsonConvert.SerializeObject(_internalObject);
			fl.Write(stream);
			fl.Flush();
			fl.Close();
		}

		public void SetObject(T obj)
		{
			_internalObject = obj;
		}
		
		public T GetObject()
		{
			return _internalObject;
		}
	}
}
