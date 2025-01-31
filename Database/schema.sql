

CREATE TABLE public."Roles" (
	"Id" int4 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	"Name" text NOT NULL,
	CONSTRAINT "PK_Roles" PRIMARY KEY ("Id")
);

CREATE TABLE public."Users" (
	"Id" int4 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	"Name" text NOT NULL,
	"Email" text DEFAULT ''::text NOT NULL,
	"Password" text DEFAULT ''::text NOT NULL,
	CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
);

CREATE TABLE public."Items" (
	"Id" int4 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	"Name" text NOT NULL,
	"Description" text NOT NULL,
	"Value" int4 NOT NULL,
	"OwnerId" int4 NULL,
	CONSTRAINT "PK_Items" PRIMARY KEY ("Id"),
	CONSTRAINT "FK_Items_Users_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES public."Users"("Id")
);
CREATE INDEX "IX_Items_OwnerId" ON public."Items" USING btree ("OwnerId");


CREATE TABLE public."UserRole" (
	"RoleId" int4 NOT NULL,
	"UserId" int4 NOT NULL,
	CONSTRAINT "PK_UserRole" PRIMARY KEY ("RoleId", "UserId"),
	CONSTRAINT "FK_UserRole_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."Roles"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_UserRole_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE
);
CREATE INDEX "IX_UserRole_UserId" ON public."UserRole" USING btree ("UserId");