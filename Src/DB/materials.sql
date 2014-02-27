CREATE TABLE materials (
 blueprintTypeID INT,	--	id of blueprint using this material 
 activityID INT,	--	building, copying, etc
 requiredTypeID INT,	--	id of resource used for this activity
 quantity INT,	--	how many of this resource is used
 damagePerJob float,	--	how much of the resource is expended
 baseMaterial INT,	--	how much is the base material.  0 means unaffected by waste, >=quantity means entirely affected
 --PRIMARY KEY (blueprintTypeID, activityID, requiredTypeID)
 CONSTRAINT materialsKey PRIMARY KEY (blueprintTypeID,activityID,requiredTypeID)
);

---drop table materials

INSERT INTO materials
 (blueprintTypeID, activityID, requiredTypeID, quantity, damagePerJob, baseMaterial)
SELECT
 rtr.typeID,
 rtr.activityID,
 rtr.requiredTypeID,
 (rtr.quantity + ISNULL(itm.quantity, 0)),
 rtr.damagePerJob,
 itm.quantity
FROM invBlueprintTypes AS b
 INNER JOIN ramTypeRequirements AS rtr
  ON rtr.typeID = b.blueprintTypeID
  AND rtr.activityID = 1 -- manufacturing
 LEFT OUTER JOIN invTypeMaterials AS itm
  ON itm.typeID = b.productTypeID
  AND itm.materialTypeID = rtr.requiredTypeID
WHERE rtr.quantity > 0;
 
INSERT INTO materials
 (blueprintTypeID, activityID, requiredTypeID, quantity, damagePerJob, baseMaterial)
SELECT
 b.blueprintTypeID,
 1,                  -- manufacturing activityID
 itm.materialTypeID, -- requiredTypeID
 (itm.quantity
  - ISNULL(sub.quantity * sub.recycledQuantity, 0)
 ),                  -- quantity
 1,                  -- damagePerJob
 (itm.quantity
  - ISNULL(sub.quantity * sub.recycledQuantity, 0)
 )                   -- baseMaterial
FROM invBlueprintTypes AS b
 INNER JOIN invTypeMaterials AS itm
  ON itm.typeID = b.productTypeID
 LEFT OUTER JOIN materials m
  ON b.blueprintTypeID = m.blueprintTypeID
  AND m.requiredTypeID = itm.materialTypeID
 LEFT OUTER JOIN (
  SELECT srtr.typeID AS blueprintTypeID,  -- tech 2 items recycle into their materials
   sitm.materialTypeID AS recycledTypeID, -- plus the t1 item's materials
   srtr.quantity AS recycledQuantity,
   sitm.quantity
  FROM ramTypeRequirements AS srtr
   INNER JOIN invTypeMaterials AS sitm
    ON srtr.requiredTypeID = sitm.typeID
  WHERE srtr.recycle = 1 -- the recycle flag determines whether or not this requirement's materials are added
   AND srtr.activityID = 1
 ) AS sub
  ON sub.blueprintTypeID = b.blueprintTypeID
  AND sub.recycledTypeID = itm.materialTypeID
WHERE m.blueprintTypeID IS NULL -- partially waste-affected materials already added
 AND (itm.quantity - ISNULL(sub.quantity * sub.recycledQuantity, 0) ) > 0; -- ignore negative quantities