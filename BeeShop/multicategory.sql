/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [id]
      ,[name]
      ,[depth]
      ,[parent]
      ,[image]
      ,[urlkey]
      ,[inmenu]
      ,[description]
      ,[isactive]
      ,[metakeyword]
      ,[deleted]
  FROM [beeshop].[dbo].[category]

 

  
   WITH tableR (name,parent,id,tree_depth)
AS
(
-- Anchor member definition
    SELECT e.name,e.parent,e.id,0
    FROM [beeshop].[dbo].[category] AS e   
    WHERE parent=-1
    UNION ALL
-- Recursive member definition
    SELECT e.name,e.parent,e.id,tree_depth+1
    FROM [beeshop].[dbo].[category] AS e
    INNER JOIN tableR AS d
        ON e.parent = d.id
)
-- Statement that executes the CTE
SELECT name,parent,id,tree_depth
FROM tableR order by name,tree_depth

select * from
(
 select A.name,A.id,B.name,B.id
    FROM [beeshop].[dbo].[category] as A
    inner join [beeshop].[dbo].[category] as B on A.id=B.parent
    

	 
 