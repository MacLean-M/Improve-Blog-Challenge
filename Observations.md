Observations regarding code quality (e.g. architectural improvements, recommendations, tech debt)
-> Recommend to use standard code comment in XML format.
-> Using ViewData may result in difficult to maintain code and the implmentation should be converted to a custom object model to avoid technical debt buildup.
-> Recommend introduction of service data parsing errors to respond to risk of changes to 3rd-party API data structure.
-> Recommend improved data efficiency in API call to improve application energy efficiency and performance.

Impediments stopping completion of tasks
-> Insufficient time to complete 'post colours' change specification - remains unactioned at this time. All other changes completed.
-> Standard error handling provides technical messages only which can lead to unnecessary analysis effort when a business logic message could be used to immediately explain the error situation.
-> A "service unavailable" message is not included on the 3rd-party data source connection where applicable which can result in lost time when the network dependency is unavailable.



