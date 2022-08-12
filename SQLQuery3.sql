INSERT INTO TblTree (TreeNum,TreeRow,TreeBlock,DatePlanted) VALUES (1, 3, 'f', '2017-12-11')

SELECT *
FROM TblTree

UPDATE TblTree
SET TreeBlock = 'a'
WHERE TreeID = 4;