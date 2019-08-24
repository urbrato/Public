SELECT P.Name, C.Name 
  FROM Products AS P
  LEFT OUTER JOIN Products_Categories AS PC
    ON P.ID = PC.Product_ID
  LEFT OUTER JOIN Categories AS C
    ON C.ID = PC.Category_ID