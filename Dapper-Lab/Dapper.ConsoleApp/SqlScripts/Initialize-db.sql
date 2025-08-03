CREATE TABLE Header (
    [Id]          UNIQUEIDENTIFIER  PRIMARY KEY,
    [Name]        VARCHAR(100)      NOT NULL,
    [State]       VARCHAR(2)            NULL,
    [Expires]     DATE                  NULL,
    [Amount]      DECIMAL(18,2)         NULL,
    [Terminated]  BIT               NOT NULL
);