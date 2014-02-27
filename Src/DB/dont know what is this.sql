	--- select * from [typeBuildReqs]

    IF OBJECT_ID('[dbo].[typeBuildReqs]') IS NOT NULL
    DROP TABLE [dbo].[typeBuildReqs]
     
    CREATE TABLE [dbo].[typeBuildReqs]
    (
    typeID INT,
    activityID int,
    requiredTypeID INT,
    quantity INT,
    damagePerJob FLOAT,
    wasted   int,
     
    CONSTRAINT typetypeBuildReqs_PK PRIMARY KEY CLUSTERED
    (typeID, activityID, requiredTypeID, wasted)
    )
     
    GO
     
    INSERT INTO typeBuildReqs (typeID, activityID, requiredTypeID, quantity,
    damagePerJob,wasted)
     
    (SELECT itm1.typeID, 1 AS activityID, itm1.requiredTypeID, (itm1.quantity-
    isnull(itm2.quantity,0)) AS quantity, 1 AS damagePerJob, 1 AS wasted
     
    FROM
    (SELECT invBlueprintTypes.blueprintTypeID AS typeID, 1 AS
    activityID, invTypeMaterials.materialTypeID AS requiredTypeID,
    invTypeMaterials.quantity, 1 AS damagePerJob, 1 AS wasted
    FROM invTypeMaterials
     
    INNER JOIN invBlueprintTypes
    ON invTypeMaterials.typeID =
    invBlueprintTypes.productTypeID) AS itm1
     
    LEFT OUTER JOIN
     
    (SELECT typeID, activityID, requiredTypeID ,
    SUM(quantity) AS quantity, damagePerJob, wasted
    FROM
    (SELECT t.typeID, 1 AS activityID, itm.materialTypeID
    AS requiredTypeID , (itm.quantity * t.quantity)
    AS quantity, 1 AS damagePerJob, 1 AS wasted
     
    FROM   
    (SELECT DISTINCT rtr.typeID, rtr.requiredTypeID,
    rtr.quantity
    FROM ramTypeRequirements AS rtr
     
    INNER JOIN      invTypes AS iT
    ON rtr.requiredTypeID = iT.typeID
     
    INNER JOIN      invGroups AS iG
    ON iT.groupID = iG.groupID
     
    WHERE ((rtr.activityID = 1) AND (rtr.recycle = 1)
    AND (iG.categoryID <> 4)
    AND (iG.categoryID <> 17))) AS t
     
    INNER JOIN invTypeMaterials AS itm
    ON t.requiredTypeID = itm.typeID) AS itm3
    GROUP BY typeID, activityID, requiredTypeID , damagePerJob, wasted)
    AS itm2
     
    ON itm2.typeID = itm1.typeID AND
    itm2.activityID = itm1.activityID AND
    itm2.requiredTypeID = itm1.requiredTypeID
     
    WHERE (itm1.quantity-isnull(itm2.quantity,0)) > 0)
     
    UNION
     
    (SELECT rtr2.typeID, rtr2.activityID, rtr2.requiredTypeID, rtr2.quantity,
    rtr2.damagePerJob, 0 AS wasted
    FROM ramTypeRequirements AS rtr2
     
    INNER JOIN      invTypes AS types
    ON rtr2.requiredTypeID = types.typeID
     
    INNER JOIN      invBlueprintTypes AS bps
    ON rtr2.typeID = bps.blueprintTypeID
     
    INNER JOIN      invGroups AS groups
    ON types.groupID = groups.groupID
     
    LEFT OUTER JOIN (SELECT typeID, materialTypeID, quantity
    FROM invTypeMaterials) AS itm
    ON (bps.productTypeID = itm.typeID AND
    rtr2.requiredTypeID = itm.materialTypeID AND
    (rtr2.quantity <= itm.quantity OR
    rtr2.quantity > itm.quantity OR itm.quantity IS NULL))
     
    WHERE ((groups.categoryID <> 16) AND (rtr2.activityID = 1) AND
    (rtr2.quantity > 0)))  
    GO

/*
SELECT typeBuildReqs.*, invTypes.typeID, invTypes.typeName FROM typeBuildReqs
 JOIN invTypes ON (invTypes.typeID = typeBuildReqs.requiredTypeID)
 WHERE typeBuildReqs.typeID = 2033
 AND invTypes.groupID NOT IN (268,269,270)
 AND activityID = 1
*/