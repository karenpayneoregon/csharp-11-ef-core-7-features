SELECT      P.ProductId,
            P.[Name] AS ProductName,
            P.CategoryId,
            C.[Name] AS CategoryName
  FROM      dbo.Products AS P
 INNER JOIN dbo.Categories AS C
    ON P.CategoryId = C.CategoryId
   AND P.CategoryId = C.CategoryId;