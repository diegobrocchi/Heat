claims:
https://stack247.wordpress.com/2013/02/22/antiforgerytoken-a-claim-of-type-Nameidentifier-or-identityprovider-was-not-present-on-provided-claimsidentity/
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


https://visualstudiomagazine.com/Articles/2013/09/01/Going-Beyond-UserNames-and-Roles.aspx?Page=1

IHttpModules:
https://msdn.microsoft.com/en-us/library/vstudio/ms227673(v=vs.100).aspx

NerDinner:
http://nerddinnerbook.s3.amazonaws.com/Part9.htm


roles:
http://geekswithblogs.net/MightyZot/archive/2014/12/28/implementing-rolemanager-in-asp.net-mvc-5.aspx


routes:
http://blogs.msdn.com/b/webdev/archive/2013/10/17/attribute-routing-in-asp-net-mvc-5.aspx

upload images:
http://cpratt.co/file-uploads-in-asp-net-mvc-with-view-models/

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


Gestione degli impianti
Con riferimento al 'Libretto di impianto' come definito da 'Allegato I al DM 10 febbraio 2014 “Modelli di
libretto di impianto per la climatizzazione e di rapporto di efficienza energetica di cui al decreto del Presidente
della Repubblica n. 74/2013”'

L'impianto ('plant') è caratterizzato da:
 - identificativo 
 - indirizzo
 - trattamento acqua
 - generatori: gruppi termici o caldaie
 - generatori: macchine frigorifere/pompe di calore
 - sistemi di distribuzione
 
Un generatore puo' essere un gruppo termico oppure essere composto da uno o più bruciatori.

Terminologia:
 - Gruppo termico: ThermalUnit
 - Bruciatore: Heater




