CREATE VIEW VerbView(Id, Present, PresentE3, SimplePast, Aux, Perfect) AS 
SELECT v.Id, 
	W1.Word AS Present, 
	W2.Word AS PresentE3, 
	W3.Word AS SimplePast, 
	Aux.AuxiliaryVerb As Aux,
	W4.Word AS Perfect
FROM VerbTable AS v
INNER JOIN WordTable AS W1 ON W1.Id=v.Present
INNER JOIN WordTable AS W2 ON W2.Id=v.PresentE3
INNER JOIN WordTable AS W3 ON W3.Id=v.SimplePast
INNER JOIN AuxiliaryVerbTable AS Aux ON Aux.Id=v.AuxiliaryVerb
INNER JOIN WordTable AS W4 ON W4.Id=v.Perfect