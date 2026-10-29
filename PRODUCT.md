# Product

<!-- impeccable:product-schema 1 -->

## Platform

web

## Users

- **Student** — leent, reserveert en verlengt materialen voor schoolwerk. Zit vaak aan een school-pc of tablet, soms in een leslokaal, en wil snel zien of iets beschikbaar is.
- **Magazijnier / docent** — één rol. Registreert uitgifte en terugkomst, beheert materialen en ziet wat openstaat of te laat is.
- **Systeem** — controleert regels (blokkade, één lening per categorie), verwerkt de wachtlijst en stuurt reminder-mails.

## Product Purpose

De school leent kabels, adapters, schermen en kleine apparatuur uit via een handmatig proces bij de magazijnier. Dit product maakt die uitleen zichtbaar en zelfbedienbaar: studenten zien per vestiging wat er is, vragen aan of reserveren; de magazijnier registreert en houdt voorraad bij.

Succes = een student weet binnen enkele seconden of een materiaal beschikbaar is op zijn vestiging, en de magazijnier heeft geen Excel of briefje meer nodig.

## Positioning

Eén catalogus die altijd de werkelijke voorraad per vestiging laat zien (Heerlen en Valencia), en die de aanvraag van de student loshoudt van de registratie door de magazijnier. Materiaal is een "soort met aantal", geen uniek exemplaar.

## Operating Context

- Uitlening gebeurt aan de balie van het magazijn; de student vraagt vooraf aan.
- Twee vestigingen: Heerlen en Valencia. Voorraad is per vestiging eigen.
- Vier categorieën: kabels, stroom, kleine apparatuur, beeldschermen.
- Regels uit het functioneel ontwerp: leentermijn kiest de student zelf; max. 1 lening per categorie per student; reservering geldt voor een datum en vervalt; blokkade bij te laat geldt voor lenen én reserveren.

## Capabilities and Constraints

In scope (FO F1–F11): materialen bekijken en zoeken, uitlenen, terugbrengen, reserveren met wachtlijst, verlengen via mail-link, reminder-mail, blokkade bij te laat, materialen beheren, accounts beheren (geen zelfregistratie), onbruikbaar melden, rapportage.

Nu gebouwd: catalogus/overzicht per vestiging en het aanvraagformulier (lenen en reserveren). De rest volgt.

Buiten scope: betalingen, boetes, schadeclaims, koppeling met schoolaccount/LDAP, push- of in-app notificaties.

Nog open (uit FO): verlooptermijn van een reservering, grens voor "voorraad laag", verlengen tijdens een blokkade, welke devices precies, alleen schoolnetwerk of ook thuis, log-in/wachtwoordbeleid.

Techniek nu: Blazor Web App (.NET 10) met een gedeelde Razor Class Library `Magazijn.Components`, zodat dezelfde UI later in de mobiele app hergebruikt kan worden. Er is nog geen API; de data is mock in-memory.

## Brand Commitments

- Naam: Magazijnuitleenapplicatie (in de UI: "Magazijnuitleen").
- Omgeving: Vista College, team ICT-opleidingen.
- Bindende visuele referentie: het catalogusscherm "CATALOGUS & AANVRAGEN" uit de teamontwerpen — zwart-wit/grijs, geen kleuraccenten, categoriefilter als tekstlinks (kabels | stroom | apparatuur | beeldschermen), materialen als kaartgrid met beeld.
- Nederlands is de taal van de interface.

## Evidence on Hand

- `functioneel_ontwerp.md` — doelen, actoren, scope F1–F11, regels en open punten.
- `use_cases.md` — UC01 t/m UC09.
- `Magazijn Website/.../Magazijn.Components/Services/MagazijnService.cs` — mock-catalogus met 14 materialen, 4 categorieën, 2 vestigingen.
- Teamontwerp (screenshot via Trello, 24-09-2026) — catalogusscherm als visuele referentie.
- Geen echte voorraad-, account- of leengegevens: niets verzinnen in UI-copy of rapportages.

## Product Principles

1. **Voorraad is de waarheid.** Elk scherm dat een materiaal toont, toont ook of het er is, en waar.
2. **Aanvragen is niet uitlenen.** De student vraagt aan; pas de magazijnier maakt er een uitgifte van. De UI belooft nooit meer dan dat.
3. **Twee vestigingen, één verhaal.** Heerlen en Valencia zijn gelijkwaardig; nooit een vestiging als bijzaak behandelen.
4. **Snel naar de balie.** De student moet met zoeken en filteren binnen enkele seconden bij het juiste materiaal zijn.
5. **Regels zichtbaar, niet verstopt.** Blokkade, beschikbaarheid en reserveren worden uitgelegd op het moment dat ze gelden.

## Accessibility & Inclusion

WCAG 2.1 AA is een eis. Concreet: minimaal contrast 4.5:1 voor tekst, zichtbare focus, volledig toetsenbordbediening, labels bij alle velden, status nooit alleen via kleur, en `lang="nl"` op de pagina.
