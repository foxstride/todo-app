CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "TodoItems" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_TodoItems" PRIMARY KEY,
    "Title" TEXT NOT NULL,
    "Description" TEXT NOT NULL,
    "Finished" INTEGER NOT NULL,
    "Created" TEXT NOT NULL,
    "Updated" TEXT NOT NULL
);

INSERT INTO "TodoItems" ("Id", "Created", "Description", "Finished", "Title", "Updated")
VALUES ('00A87186-4C77-4402-82C6-8136B4B954BD', '2022-02-07 17:01:21.5138218', 'The Second Description', 0, 'Second Todo Item', '2022-02-07 17:01:21.513822');

INSERT INTO "TodoItems" ("Id", "Created", "Description", "Finished", "Title", "Updated")
VALUES ('2A329D6A-876C-4027-8DF8-7C4521839368', '2022-02-07 04:30:00', 'Make a Todo app for Tonic', 0, 'Code Interview', '2022-02-07 04:30:00');

INSERT INTO "TodoItems" ("Id", "Created", "Description", "Finished", "Title", "Updated")
VALUES ('457BEDDE-EDDD-493F-B92E-7F29D6CEFAD6', '2022-02-07 17:01:21.5138143', 'The First Description', 1, 'First Todo Item', '2022-02-07 17:01:21.5138179');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220208000121_InitialCreate', '6.0.1');

COMMIT;

