-------------------------------------------------------INSERT GEOSHAPE-------------------------------------------------------
--PARAM0: DbName
--PARAM1: Code
--PARAM2: Name
--PARAM3: DocEntry
--PARAM4: ShapeType
--PARAM5: ShapeId from MASTER DATA ("MSS_ZONA", "MSS_RUTA")

--BEGINQUERY
INSERT INTO "HELATONYS_PRUEBAS"."@MSS_GEOSHAPE" VALUES('PARAM1', 'PARAM2', 'PARAM3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'PARAM4', 'PARAM5', NULL);