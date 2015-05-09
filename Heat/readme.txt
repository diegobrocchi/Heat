claims:
https://stack247.wordpress.com/2013/02/22/antiforgerytoken-a-claim-of-type-nameidentifier-or-identityprovider-was-not-present-on-provided-claimsidentity/
http://stackoverflow.com/questions/19977833/anti-forgery-token-issue-mvc-5
http://www.codeproject.com/Articles/639458/Claims-Based-Authentication-and-Authorization
http://chris.59north.com/post/2013/03/27/Claims-based-identities-in-ASPNET-MVC-45-using-the-standard-ASPNET-providers.aspx
http://stackoverflow.com/questions/21807528/claims-based-authorization-with-asp-net-mvc
http://geekswithblogs.net/shahed/archive/2010/02/05/137795.aspx
http://fczaja.blogspot.it/2013/12/claims-based-authorization-in-mvc4.html
http://visualstudiomagazine.com/articles/2013/08/01/leveraging-claims-based-security-in-aspnet-45.aspx
https://www.simple-talk.com/dotnet/asp.net/thoughts-on-asp.net-mvc-authorization-and-security-/
http://typecastexception.com/post/2014/06/22/ASPNET-Identity-20-Customizing-Users-and-Roles.aspx
http://leastprivilege.com/2012/10/26/using-claims-based-authorization-in-mvc-and-web-api/


https://visualstudiomagazine.com/Articles/2013/09/01/Going-Beyond-Usernames-and-Roles.aspx?Page=1

IHttpModules:
https://msdn.microsoft.com/en-us/library/vstudio/ms227673(v=vs.100).aspx

NerDinner:
http://nerddinnerbook.s3.amazonaws.com/Part9.htm


roles:
http://geekswithblogs.net/MightyZot/archive/2014/12/28/implementing-rolemanager-in-asp.net-mvc-5.aspx


processo emissione del documento.

E' possibile inserire un nuovo documento e successivamente selezionare il cliente;
oppure selezionare il cliente e emettere il documento assegnando già il cliente.

L'emissione del documento consiste in:
 - assegnazione del numero del documento in base al numeratore assegnato (vedi 'processo di gestione dei numeratori');
 - attribuzione dello stato 'in emissione - stato temporaneo' al documento;

processo di gestione dei numeratori
Il numeratore è l'oggetto responsabile della assegnazione di un codice seriale ad un oggetto.
Le caratteristiche che il processo deve garantire sono:
 - univocità del valore restituito, con attenzione alle condizioni di accesso concorrente alla risorsa;
 - periodicità del numeratore: la sequenza deve poter essere resettata. Il reset può essere automatico nel periodo, oppure forzato manualmente.
 - la periodicità può essere di questi tipi: nessuna (o infinito), giornaliera, settimanale, mensile, annuale, biannuale;
 - il numeratore possiede uno schema;
