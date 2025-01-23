INSERT INTO "Roles" ("Name") VALUES
  ('Admin'),
  ('Modifier'),
  ('Viewer');
 
 
 INSERT INTO "Items" ("Name", "Description", "Value") VALUES
  ('Item1', 'Descrição do Item 1', 29.99),
  ('Item2', 'Descrição do Item 2', 49.99),
  ('Item3', 'Descrição do Item 3', 99.99),
  ('Item4', 'Descrição do Item 4', 199.99);
 
INSERT INTO public."Users" ("Name", "Email", "Password") VALUES
  ('João', 'transportadoraplatina@gmail.com', '81dc9bdb52d04dc20036dbd8313ed055'),
  ('Maria', 'maria@gmail.com', '81dc9bdb52d04dc20036dbd8313ed055'),
  ('Pedro', 'pedro@gmail.com', '81dc9bdb52d04dc20036dbd8313ed055'),
  ('Ana', 'ana@gmail.com', '81dc9bdb52d04dc20036dbd8313ed055');
 
 
INSERT INTO "UserRole" ("UserId", "RoleId") VALUES
  ((SELECT "Id" FROM "Users" WHERE "Email" = 'transportadoraplatina@gmail.com'), (SELECT "Id" FROM "Roles" WHERE "Name" = 'Admin')),
  ((SELECT "Id" FROM "Users" WHERE "Email" = 'maria@gmail.com'), (SELECT "Id" FROM "Roles" WHERE "Name" = 'Modifier')),
  ((SELECT "Id" FROM "Users" WHERE "Email" = 'pedro@gmail.com'), (SELECT "Id" FROM "Roles" WHERE "Name" = 'Modifier')),
  ((SELECT "Id" FROM "Users" WHERE "Email" = 'ana@gmail.com'), (SELECT "Id" FROM "Roles" WHERE "Name" = 'Viewer'));