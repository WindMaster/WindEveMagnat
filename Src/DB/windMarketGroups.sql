/*
	De-norm invMarketGroups to prepare for loading to TreeView
*/

-- select * from windMarketGroups 
-- drop table windMarketGroups

with groupTree(marketGroupID, parentGroupID, marketGroupName, level, path) as 
(
	SELECT marketGroupID, parentGroupID, marketGroupName, 0 as level, convert(varchar(max),right(row_number() over (order by marketGroupID),10)) path
	FROM invMarketGroups
	WHERE parentGroupID is null
UNION ALL
	SELECT c2.marketGroupID, c2.parentGroupID, c2.marketGroupName, groupTree.level + 1,
	path + '-' + convert(varchar(max),right(row_number() over (order by groupTree.marketGroupID),10))
	FROM invMarketGroups c2
	INNER JOIN groupTree ON groupTree.marketGroupID = c2.parentGroupID
)

SELECT * INTO windMarketGroups
FROM groupTree
order by level,marketGroupName
