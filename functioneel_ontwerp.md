# Functioneel Ontwerp — Magazijnuitleenapplicatie

| | |
|---|---|
| **Opdrachtgever** | Team Ict-opleidingen (Vista College), vakdocent = klant |
| **Team** | Jasper van Kalsbeek (groepsleider, documentatie, presentatie), Chester (inventarisatie), Len van der Spoel (ERD/datamodel), Rebecca Eerlingen (klantcontact/FO — op moment van schrijven niets opgeleverd) |
| **Status** | Concept v1 — open punten gemarkeerd met **[OPEN]** |
| **Datum** | 22 september 2026 |

---

## 1. Inleiding en doel

De school heeft diverse materialen (kabels, adapters, schermen, kleine apparatuur) die studenten lenen voor schoolwerk. Uitlening gebeurt nu handmatig via de magazijnier. Het doel is een **magazijnuitleenapplicatie** waarmee:

- studenten materialen kunnen bekijken, aanvragen, reserveren en verlengen;
- het magazijn (docent) uitgifte en terugkomst registreert en de voorraad beheert.

De levering bestaat uit een **technisch + functioneel ontwerp** en een **werkende app**. Oplevering tijdens de Expo op **15 oktober 2026**.

## 2. Actoren en rollen

- **Student** — leent, reserveert en verlengt materialen via de app. Mag zelf geen uitgifte/terugkomst registreren.
- **Magazijnier / Docent** — één rol (dezelfde persoon). Registreert uitlening en terugkomst, beheert materialen, accounts en rapporten.
- **Systeem** — controleert regels (blokkades, limieten), stuurt mail-reminders, verwerkt wachtlijst.

## 3. Scope

### In scope
| # | Functionaliteit | Detail |
|---|---|---|
| F1 | Materialen bekijken | Bladeren/zoeken per categorie |
| F2 | Uitlenen | Student vraagt aan, magazijnier registreert uitgifte |
| F3 | Terugbrengen | Magazijnier registreert, voorraad wordt verhoogd |
| F4 | Reserveren + wachtlijst | Niet beschikbaar → reserveren voor datum, vervalt op datum |
| F5 | Verlengen | Via mail-link, onbeperkt keer |
| F6 | Reminder-mail | Verstuurt herinnering met verlenglink |
| F7 | Blokkade bij te laat | Blokkeert lenen én reserveren; eindigt automatisch bij retour |
| F8 | Materialen beheren | Toevoegen/aanpassen; aanmelden nieuwe materialen door docent |
| F9 | Accounts beheren | Magazijnier maakt accounts aan, geen zelfregistratie |
| F10 | Onbruikbaar melden | Per lening-regel, valt uit beschikbare telling |
| F11 | Rapportage | Openstaand, te laat, meest geleend, voorraad laag |

### Out of scope
- Theoretisch: geen meldingen anders dan de verleng-reminder (geen push-SMS, geen notificaties in-app)
- Geen betalingen, boetes of schadeclaims
- Geen koppelingen met andere systemen (Schoolaccount/LDAP) — eigen accounts [check met team]

## 4. Functionele eisen

Uitgewerkt in het aparte use case-document (UC01 t/m UC09) en eventuele user stories. Kernregels:

- **Leentermijn:** wordt door de student opgegeven (terugbrengdatum), geen vaste termijn.
- **Max. 1 lening per categorie** ("thema") tegelijk per student. Categorieën: kabels, stroom, kleine apparatuur, beeldschermen.
- **Materiaalmodel:** "soort met aantal" (teller, geen unieke exemplaren). "1 per stuk" = maximaal 1 lening tegelijk op die soort.
- **Blokkade:** openstaande te-laat-blokkade → mag niet lenen én niet reserveren. Eindigt automatisch bij retour.
- **Reservering:** geldt voor opgegeven datum, vervalt op die datum; bij geen beschikbaarheid komt de student op de wachtlijst.
- **Verlengen:** onbeperkt keer via mail-link. Blokkade? → **[OPEN] wij geweigerd?**
- **[OPEN] Verlooptermijn reservering:** na hoeveel dagen vervalt een onafgehaalde reservering?**
- **[OPEN] Voorraad laag-grens:** bij welk resterend aantal valt een materiaal onder "voorraad laag"?**
- **[OPEN] Beschadigde retour:** moet er een vervangend item vóór gereserveerde studenten, of is volstaan met onbruikbaar melden (F10)?**

## 5. Niet-functionele eisen

Nog niet formeel vastgelegd. Nader te bepalen met klant:
- Techniek: MAUI (client) → ASP.NET API → PostgreSQL (bevestigd)
- **[OPEN]** op welke platforms/devices de app moet draaien (Windows-pc's? tablets?)
- **[OPEN]** alleen beschikbaar op schoolnetwerk of ook thuis?
- **[OPEN]** responstijd / aantal gelijktijdige gebruikers
- **[OPEN]** beveiliging/rollen (log-in, wachtwoordbeleid)

## 6. Aannames en risico's

| # | Risico | Impact | Beheersmaatregel |
|---|---|---|---|
| R1 | Rebecca levert niet (rol klantcontact/FO) | Vertraging FO, klant niet op de hoogte | Taken overgenomen door Jasper; contract-sanctie indien nodig |
| R2 | Open klantvragen (verlooptermijn, voorraadlaag-grens, verlengen bij blokkade) | Interpreteren verkeerd → app volgt ander gedrag dan klant wil | Checklist klantafstemming vóór oplevering |
| R3 | Plan-omvang: 2 schoolweken (opdracht) vs 3 (contract) | Verwarring deadlines | Planning op 2 weken + buffer tot 15 okt |

## 7. Klantafstemming

- Klantgesprek: **gevoerd** (door Jasper namens Rebecca) — bevestigde eisen verwerkt in dit document.
- **[OPEN]** Notulen retour ter bevestiging: verstuurd? Bevestigd door klant?
- **[OPEN]** Vragenlijst open punten (zie sectie 4) nog beantwoorden door klant.
- **[OPEN]** Feedback technisch docenten vóór Expo verwerken.