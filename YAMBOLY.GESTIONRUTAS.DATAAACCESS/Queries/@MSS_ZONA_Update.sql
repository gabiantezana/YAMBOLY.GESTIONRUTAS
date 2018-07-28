-------------------------------------------------------DISABLE GEOSHAPE_D-------------------------------------------------------
--PARAM0: DbName
--PARAM1: Code
--PARAM2: Coordinates

--BEGINQUERY
UPDATE "SBO_HELATONYS"."@MSS_ZONA" SET "U_COORDINATESARRAY" = 'PARAM2' WHERE "Code" = 'PARAM1';