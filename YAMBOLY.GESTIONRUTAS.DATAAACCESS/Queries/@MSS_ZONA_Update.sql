-------------------------------------------------------DISABLE GEOSHAPE_D-------------------------------------------------------
--PARAM0: DbName
--PARAM1: Code
--PARAM2: Coordinates

--BEGINQUERY
UPDATE "HELATONYS_PRUEBAS"."@MSS_ZONA" SET "U_COORDINATESARRAY" = 'PARAM2' WHERE "Code" = 'PARAM1';