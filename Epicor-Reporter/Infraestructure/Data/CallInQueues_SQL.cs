



namespace Infraestructure.Data
{
    public static  class CallInQueues_SQL
    {
       private static string query = string.Empty;


        public static string TotalCount( string queryParams = "") 
        {
            query = @"
               SELECT COUNT(*) AS TotalRecords
                FROM (
                    SELECT 
                        Sc.SupportCallID,
                        Sc.Number,
                        CASE 
                            WHEN Sc.SupportCallType = 'I' THEN 'Incident'
                            WHEN Sc.SupportCallType = 'R' THEN 'Request For Change'
                            WHEN Sc.SupportCallType = 'S' THEN 'Service Request'
                            ELSE 'NO DEFINIDO'
                        END AS Types,
                        Sc.Summary,
                        Que.Name AS [Queue],
                        Status.Name AS [Status],
                        DATEADD(HH, -6, Sc.OpenDate) AS OpenDate,
                        DATEADD(HH, -6, Scs.DueDateBySla) AS DueDate,
                        -- Obtener la fecha inicial (StartDate)
                        (SELECT MIN(DATEADD(HH, -6, StartDate))
                         FROM SupportCallAssignToHistory AS SCATH
                         WHERE SCATH.SupportCallID = Sc.SupportCallID) AS StartDate,
                        -- Obtener la fecha final (EndDate)
                        (SELECT MAX(DATEADD(HH, -6, StartDate))
                         FROM SupportCallAssignToHistory AS SCATH
                         WHERE SCATH.SupportCallID = Sc.SupportCallID) AS DateAssignedTo,
                        ( SELECT COUNT(*)
                        FROM AttributeValue AS Av  
                        LEFT JOIN AttributeBoundColumn AS Abc ON Abc.AttributeBoundColumnID = Av.AttributeBoundColumnID
                        LEFT JOIN AttributeColumn AS Ac ON Ac.AttributeColumnID = Abc.AttributeColumnID
                        WHERE ParentID=Sc.SupportCallID) As Attribute,
                        Pri.Description AS [Priority]
                    FROM 
                        SupportCall AS Sc WITH (NOLOCK)
                    LEFT JOIN 
                        Queue AS Que WITH (NOLOCK) ON Que.QueueID = Sc.AssignToQueueID
                    LEFT JOIN 
                        SupportCallStatus AS Status WITH (NOLOCK) ON Status.SupportCallStatusID = Sc.StatusID
                    LEFT JOIN  
                        SupportCallSLAStatus Scs ON Scs.SupportCallID = Sc.SupportCallID
                    LEFT JOIN 
                        ValueListEntry AS Pri ON Pri.ValueListEntryID = SC.PriorityID
                    WHERE 
                        Sc.Closed = 0  
                        AND Sc.AssignToQueueID IS NOT NULL " + queryParams+@" 
                ) AS Subquery;
             ";
            return query; 
        }

        public static string Query(int pageSize = 50, int startRow = 0, string queryParams = "")
        {
            query = @"                 
                SELECT 
                    Sc.SupportCallID,
                    Sc.Number,
                    CASE 
                        WHEN Sc.SupportCallType = 'I' THEN 'Incident'
                        WHEN Sc.SupportCallType = 'R' THEN 'Request For Change'
                        WHEN Sc.SupportCallType = 'S' THEN 'Service Request'
                        ELSE 'NO DEFINIDO'
                    END AS Types,
                    Sc.Summary,
                    Que.Name AS [Queue],
                    Status.Name AS [Status],
                    DATEADD(HH, -6, Sc.OpenDate) AS OpenDate,
	                DATEADD(HH, -6, Scs.DueDateBySla) AS DueDate,
	                -- Obtener la fecha inicial (StartDate)
                    (SELECT MIN( DATEADD(HH, -6, StartDate))--MIN(StartDate)
                     FROM SupportCallAssignToHistory AS SCATH
                     WHERE SCATH.SupportCallID = Sc.SupportCallID) AS StartDate,
                    -- Obtener la fecha final (EndDate)
                    (SELECT MAX( DATEADD(HH, -6, StartDate))
                     FROM SupportCallAssignToHistory AS SCATH
                     WHERE SCATH.SupportCallID = Sc.SupportCallID) AS DateAssignedTo,
                    ( SELECT COUNT(*)
                    FROM AttributeValue AS Av  
                    LEFT JOIN AttributeBoundColumn AS Abc ON Abc.AttributeBoundColumnID = Av.AttributeBoundColumnID
                    LEFT JOIN AttributeColumn AS Ac ON Ac.AttributeColumnID = Abc.AttributeColumnID
                    WHERE ParentID=Sc.SupportCallID) As Attribute,
                Pri.Description AS [Priority]
                FROM 
                    SupportCall AS Sc WITH (NOLOCK)
                LEFT JOIN 
                    Queue AS Que WITH (NOLOCK) ON Que.QueueID = Sc.AssignToQueueID
                LEFT JOIN 
                    SupportCallStatus AS Status WITH (NOLOCK) ON Status.SupportCallStatusID = Sc.StatusID
                LEFT JOIN  SupportCallSLAStatus Scs ON Scs.SupportCallID = Sc.SupportCallID
                LEFT JOIN ValueListEntry AS Pri ON Pri.ValueListEntryID = SC.PriorityID
	                WHERE Sc.Closed=0  AND Sc.AssignToQueueID IS NOT NULL " + queryParams+ @"  ORDER BY  Sc.OpenDate DESC
                  ";
            return query;
        }


        public static string Query(string param)
        {
            query = @"                 
               SELECT 
            Ac.LabelText AS Attribute ,
            Av.ValueShortText AS Value
            FROM AttributeValue AS Av  
            LEFT JOIN AttributeBoundColumn AS Abc ON Abc.AttributeBoundColumnID = Av.AttributeBoundColumnID
            LEFT JOIN AttributeColumn AS Ac ON Ac.AttributeColumnID = Abc.AttributeColumnID
            WHERE " + param + @"
                  ";
            return query;
        }
       
    }
}
