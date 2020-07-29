use PizzaBoxDb;
go

Select *
FROM Pizza.Pizza;
go

Select *
FROM Pizza.[Order];
go

Select *
FROM Pizza.[User];
go

Select *
FROM Pizza.[Toppings];
go

Select *
FROM Pizza.Store;
go

DELETE
from Pizza.[Order]
where UserId = 1;
go

DELETE
from Pizza.[User]
where name = 'test';
go

DELETE
from Pizza.Store
where name = 'North';
go

DELETE
from Pizza.Pizza
where name = 'test';
go

DELETE
from Pizza.[Order]
where done = 1;
go