-------------------------------------------------------UPDATE CRD1 - Dirección fiscal-------------------------------------------------------
--PARAM0: DbName
--PARAM1: ClientCardCode
--PARAM2: Coordinates	

--BEGINQUERY
UPDATE "HELATONYS_PRUEBAS"."CRD1" SET "U_COORDINATESARRAY" ='PARAM2' WHERE "Address" = 'DIRECCION FISCAL' AND "CardCode" = 'PARAM1';