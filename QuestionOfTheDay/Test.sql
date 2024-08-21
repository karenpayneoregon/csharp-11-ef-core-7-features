SELECT Main.SubjectID,
	LEFT(Main.Students, LEN(Main.Students) - 1) AS "Students"
FROM (
	SELECT DISTINCT ST2.SubjectID,
		(
			SELECT ST1.StudentName + ',' AS [text()]
			FROM dbo.Students ST1
			WHERE ST1.SubjectID = ST2.SubjectID
			ORDER BY ST1.SubjectID
			FOR XML PATH(''),
				TYPE
			).value('text()[1]', 'nvarchar(max)') Students
	FROM dbo.Students ST2
	) Main;