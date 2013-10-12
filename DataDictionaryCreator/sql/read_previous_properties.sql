IF (@@MICROSOFTVERSION / 0x01000000) >= 9
BEGIN

	SELECT DISTINCT ex.name
	FROM sys.columns c  
	LEFT OUTER JOIN sys.extended_properties ex ON ex.major_id = c.object_id AND ex.minor_id = c.column_id AND ex.name != 'MS_Description'  
	WHERE OBJECTPROPERTY(c.object_id, 'IsMsShipped')=0  
	AND ex.name is not null
	
END
ELSE BEGIN

	SELECT DISTINCT s.name 
	FROM INFORMATION_SCHEMA.COLUMNS i_s 
	INNER JOIN sysproperties s ON s.id = OBJECT_ID(i_s.TABLE_SCHEMA+'.'+i_s.TABLE_NAME) AND s.smallid = i_s.ORDINAL_POSITION AND s.name != 'MS_Description' 
	WHERE OBJECTPROPERTY(OBJECT_ID(i_s.TABLE_SCHEMA+'.'+i_s.TABLE_NAME), 'IsMsShipped')=0 

END