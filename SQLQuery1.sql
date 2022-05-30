
SELECT * FROM TblTree
SELECT * FROM TblHarvest

Update TblTree
Set TreeNum = '1'	
Where TreeId = 1;

Insert into TblTree(TreeNum, TreeRow, TreeBlock)
Values (3, 1, 'a' );

Insert into TblHarvests(TreeId, ThinDate, BeforeThinCount, AfterThinCount)
Values (3, '2021-12-17', 1290, 870);