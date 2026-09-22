# Use Cases — Magazijnuitleenapplicatie

Actoren: **Student** (leneer/reserverer), **Magazijnier/Docent** (beheer + uitgifte), **Systeem**.

Globale regels (gelden voor alle UC's):
- Max. 1 tegelijktijdige lening per categorie per student
- Te late student (open blokkade) kan niet lenen **en niet reserveren**
- Leentermijn wordt door de student opgegeven (terugbrengdatum)
- Blokkade eindigt automatisch bij retour

## UC01 — Inloggen
- **Actor:** Student, Magazijnier
- **Trigger:** Gebruiker opent de app
- **Flow:**
  1. Gebruiker vult gebruikersnaam + wachtwoord in
  2. Systeem controleert de gegevens
  3. Systeem toont het menu passend bij de rol
- **Uitzondering:** Verkeerde gegevens → foutmelding, opnieuw invoeren

## UC02 — Materiaal uitlenen (aanvraag)
- **Actor:** Student en Magazijnier
- **Trigger:** Student wil materiaal lenen
- **Preconditie:** Student ingelogd, geen open blokkade, nog geen open lening in die categorie
- **Flow:**
  1. Student vraagt materiaal aan en geeft de gewenste terugbrengdatum op
  2. Systeem controleert: beschikbaar aantal > 0 + regels (max 1 per categorie, geen blokkade)
  3. Magazijnier registreert de uitgifte
  4. Systeem verlaagt het beschikbare aantal en opent een lening
- **Uitzondering:**
  - Niet beschikbaar → student kan "Reserveren" kiezen (UC03)
  - Blokkade of max. bereikt → systeem wijst de aanvraag af met reden

## UC03 — Reserveren (met wachtlijst)
- **Actor:** Student
- **Trigger:** Materiaal is niet beschikbaar op de gewenste datum
- **Preconditie:** Student ingelogd, geen open blokkade
- **Flow:**
  1. Student reserveert materiaal voor een datum
  2. Is er geen vrije planning → student komt op de wachtlijst
  3. Systeem geeft een volgend in de wachtlijst automatisch voorrang bij beschikbaarheid
  4. Reservering vervalt na de opgegeven datum
- **Uitzondering:** Blokkade → reserveren geweigerd

## UC04 — Verlengen
- **Actor:** Student (via mail-link)
- **Trigger:** Student ontvangt mail-herinnering met verlenglink
- **Flow:**
  1. Student klikt op de verlenglink in de mail
  2. Systeem schuift de terugbrengdatum op (nieuwe datum invullen)
  3. Student bevestigt
- **Regel:** Verlengen kan onbeperkt keer
- **Uitzondering:** Onderbroken door blokkade? → verlengen geweigerd als er een open blokkade is

## UC05 — Terugbrengen registreren
- **Actor:** Magazijnier/Docent
- **Trigger:** Student levert materiaal in
- **Flow:**
  1. Magazijnier registreert de terugkomst op de lening
  2. Systeem verhoogt het beschikbare aantal
  3. Was de student te laat? → blokkade eindigt automatisch
  4. Stond de student op de wachtlijst? → systeem toont de reservering als ophaalbaar
- **Uitzondering:** Materiaal is beschadigd → UC06

## UC06 — Onbruikbaar melden
- **Actor:** Magazijnier
- **Trigger:** Materiaal komt beschadigd terug of blijkt kapot
- **Flow:**
  1. Magazijnier meldt het materiaal onbruikbaar op de lening-regel
  2. Systeem laat het uit de beschikbare telling vallen
- **Regel:** Melding per lening-regel (teller-model), geen uniek exemplaar-ID

## UC07 — Materialen beheren
- **Actor:** Magazijnier
- **Trigger:** Nieuwe materialen aangemeld (door docent) of aanpassing nodig
- **Flow:**
  1. Magazijnier voegt materiaal toe (naam, categorie, aantal, omschrijving)
  2. Systeem slaat het op onder de gekozen categorie
- **Uitzondering:** Niet-bestaande categorie → categorie eerst aanmaken

## UC08 — Account aanmaken student
- **Actor:** Magazijnier
- **Trigger:** Nieuwe student heeft app-toegang nodig
- **Flow:**
  1. Magazijnier maakt account aan met studentgegevens
  2. Student kan inloggen met die account
- **Regel:** Geen zelfregistratie — accounts worden door de magazijnier aangemaakt

## UC09 — Rapport inzien
- **Actor:** Magazijnier
- **Trigger:** Beheerder wil een overzicht bekijken
- **Available reports:**
  - Openstaande leningen (wie heeft wat)
  - Te late leningen
  - Meest geleende materialen
  - Voorraad laag (aantal →