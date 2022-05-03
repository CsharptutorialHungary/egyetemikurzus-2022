* A téma : Hangszerüzlet

A kódhoz mellékelek egy SQL querry-t is, localhoston futtattam MSSQL-t mivel oda töltöttem adatokkal két darab táblát a szoftverhez.
Ha esetleg nem töltene be a database, akkor HangszerUzlet néven készítettem el két táblával: 

Hangszer:
Id - auto-inc primary key; 
Nev - nvarchar(50); 
Tipus - nvarchar(50); 
Ar - int;

HangszerTipus:
Id - auto-inc primary key;
Nev - nvarchar(50);

A programban betölthetők az adatok, illetve működő CRUD-ot tartalmaz, amiket LINQ-val csináltam meg. emellett immutable változókat is (Akciók).
A felvitt adatokat kilehet menteni az általunk választott helyre serializálva XML formátumba. try catchek kiírják ha valamilyen probléma, exception van.
Több helyen is van List, például a típusok kiválasztásánál amikor új hangszert szerettnénk felvinni, ott listából tölti be a választható típusokat.
async rész a hangszer beszúrásánál van. az ár felvitelénél nettót adunk meg, viszont átszámolja bruttóra és úgy kerül feltöltésre.
