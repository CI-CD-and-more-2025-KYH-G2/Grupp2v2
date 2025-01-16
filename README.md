**Uppgiftsbeskrivning: C# Konsolapplikation och Docker Container f�r Kontroll av Svenskt Personnummer**

V�lj gruper sj�lva om ca 4 personer och skriv upp er i f�ljande dokument senast m�ndag 13/1 kl 8.30
https://docs.google.com/spreadsheets/d/1qWvunKB7zd8lB_Mn9he6-arAcEWzwoy2oy0n5ZASFn8/edit?usp=sharing

M�let med denna uppgift �r att skapa en konsolapplikation i C#, som fungerar som en kontroll av ett svenskt personnummer. Applikationen ska kunna verifiera om ett givet personnummer �r korrekt. Dessutom ska du skriva enhetstester f�r applikationen och anv�nda GitHub Actions f�r att automatisera testning samt bygga och publicera en Docker-container till DockerHub.
L�s mer om personnummer : https://sv.wikipedia.org/wiki/Personnummer_i_Sverige

**Krav:**

1. **Skapa en C# Konsolapplikation f�r Personnummerkontroll:**
   - Skapa en konsolapplikation som tar emot ett svenskt personnummer och verifierar dess korrekthet.
   - Anv�nd C# f�r att implementera kontrolllogiken f�r personnumret.

2. **Skriv enhetstester:**
   - Skriv enhetstester f�r olika delar av din personnummerkontrollapplikation.
   - Anv�nd ett enhetstestramverk som NUnit eller XUnit.

3. **Anv�nd GitHub Actions f�r kontinuerlig integration:**
   - Konfigurera GitHub Actions f�r att automatisera bygget och enhetstestningen av projektet.

4. **Bygga och publicera en Docker-container:**
   - Skapa en Dockerfile f�r att paketera din personnummerkontrollapplikation i en Docker-container.
   - Konfigurera GitHub Actions f�r att bygga Docker-container och publicera den p� DockerHub.
   - Anv�nd GitHub Secrets f�r att s�kert lagra och anv�nda DockerHub-credential.

5. **Dokumentation:**
   - Skriv dokumentation f�r hur man kan k�ra och testa personnummerkontrollapplikationen lokalt och hur man kan dra ner och k�ra Docker-containern.
   - Inkludera �ven information om svenska regler f�r personnummer och hur din applikation genomf�r kontrollen.
   - Inkludera dokumentationen i README.md i ert github projekt

**Deadline:**

Inl�mning ska ske senast 17/1 klockan 23.59 p� omniway. Alla gruppmedlemmar l�mnar in l�nk till GitHub repot.
Onsdag 15/1 ska varje grupp g�ra en avst�mning med utbildaren.

Lycka till!
________________________________________
________________________________________
________________________________________

<u>**Projektets dokumentation**</u>

**Svenska regler f�r personnummer**

Ett svenskt personnummer best�r av f�ljande format:
YYYYMMDD-XXXX eller YYMMDD-XXXX, med eller utan bindestreck.
YY eller YYYY: �r, kan anges med 2 eller 4 siffror.
MM: M�nad, 1-12.
DD: Dag 1-31.
XXXX: De tre f�rsta siffrorna efter bindestrecket �r ett unikt individnummer som identifierar personen. Innan 1990 angav de 2 f�rsta av dessa siffrorna vilket l�n personen var f�dd i. Sedan 1990 �r dessa siffror slumpvis valda. Den tredje siffran avsl�jar juridiskt k�n, udda siffra = man, j�mn siffra = kvinna.
Den sista siffran �r en kontrollsiffra som ber�knas med hj�lp av Luhn-algoritmen. Den s�kerst�ller att hela personnumret �r korrekt.
________________________________________
Hur applikationen validerar personnummer
Applikationen best�r av en klass, PersonalNumberValidator, som stegvis kontrollerar ett personnummer enligt de svenska reglerna. Valideringsprocessen sker i f�ljande steg:
1. Rensa personnumret fr�n bindestreck och mellanslag
Metoden CleanPersonalNumber tar bort bindestreck och mellanslag fr�n anv�ndarens inmatning f�r att f�renkla valideringen.
Exempel: 19851231-1234 omvandlas till 198512311234.
2. Kontrollera att formatet �r korrekt
Metoden IsValidFormat verifierar att personnumret best�r av antingen 10 eller 12 siffror och att det endast inneh�ller numeriska v�rden.
3. Kontrollera att datumdelen �r giltig
Metoden IsValidDate kontrollerar om de f�rsta siffrorna i personnumret motsvarar ett giltigt datum i formatet yyyyMMdd (f�r 12 siffror) eller tolkar datumet med hj�lp av sekel (f�r 10 siffror):
�	F�r 10-siffriga personnummer avg�rs �rhundradet baserat p� �rtalet:
o	Om �rtalet �r h�gre �n nuvarande �r tolkas som 19xx.
o	Annars som 20xx
Denna metod kommer allts� inte fungera f�r personer som �r �ldre �n 100 �r och som anger 10 siffror.
�	DateTime.TryParseExact anv�nds f�r att s�kerst�lla att datumen �r giltiga.

4. Kontrollera Luhn-algoritmen
Metoden PassesLuhnAlgorithm anv�nder Luhn-algoritmen f�r att validera den sista siffran (kontrollsiffran).
Processen:
1.	Om personnumret har 12 siffror tas de f�rsta tv� siffrorna (�rhundrade) bort.
2.	Algoritmen itererar genom varje siffra i personnumret, r�knat fr�n h�ger till v�nster:
o	Varannan siffra multipliceras med 2.
o	Om resultatet blir st�rre �n 9, subtraheras 9 fr�n resultatet. Det �r samma som att addera de tv� siffrorna till varandra. 
3.	Summan av alla modifierade siffror ber�knas.
4.	Kontrollera att summan �r delbar med 10.
Om summan �r j�mnt delbar med 10 anses personnumret vara giltigt enligt Luhn-algoritmen.
5. Helhetsvalidering
Metoden ValidatePersonalNumber anropar f�ljande steg i turordning:
1.	Rensa personnumret.
2.	Kontrollera formatet.
3.	Validera datumdelen.
4.	Kontrollera Luhn-algoritmen.
Om samtliga steg godk�nns anses personnumret giltigt.

Exempel p� anv�ndning
1.	Applikationen beg�r inmatning fr�n anv�ndaren via Console.ReadLine().
2.	Metoden ValidatePersonalNumber utf�r valideringen.
3.	Resultatet (giltigt eller ogiltigt) presenteras i konsolen.

