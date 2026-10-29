---
name: Magazijnuitleen
description: Catalogus en uitleen van schoolmaterialen per vestiging
colors:
  navy-deep: "#123b6d"
  ink: "#25384d"
  body: "#5b6776"
  accent: "#1b6ec2"
  accent-soft: "#eaf3ff"
  surface: "#ffffff"
  surface-muted: "#f5f8fc"
  surface-row: "#f8fbfe"
  border: "#dbe5ef"
  border-soft: "#e6edf4"
  ok-bg: "#e7f7ed"
  ok-text: "#146c2e"
  warn-bg: "#fff4d6"
  warn-text: "#8a5a00"
  danger-bg: "#fde8e8"
  danger-text: "#a61b1b"
typography:
  heading:
    fontFamily: "'Helvetica Neue', Helvetica, Arial, sans-serif"
    fontSize: "clamp(1.6rem, 3vw, 2.2rem)"
    fontWeight: 700
    lineHeight: 1.2
  section-title:
    fontFamily: "'Helvetica Neue', Helvetica, Arial, sans-serif"
    fontSize: "1.15rem"
    fontWeight: 700
  body:
    fontFamily: "'Helvetica Neue', Helvetica, Arial, sans-serif"
    fontSize: "1rem"
    fontWeight: 400
    lineHeight: 1.5
  label:
    fontFamily: "'Helvetica Neue', Helvetica, Arial, sans-serif"
    fontSize: "0.9rem"
    fontWeight: 600
  table-label:
    fontFamily: "'Helvetica Neue', Helvetica, Arial, sans-serif"
    fontSize: "0.8rem"
    fontWeight: 700
    letterSpacing: "0.03em"
rounded:
  card: "0.75rem"
  option: "0.6rem"
  pill: "999px"
spacing:
  xs: "0.35rem"
  sm: "0.6rem"
  md: "1rem"
  lg: "1.5rem"
components:
  button-primary:
    backgroundColor: "{colors.accent}"
    textColor: "{colors.surface}"
    rounded: "{rounded.option}"
    padding: "0.5rem 1rem"
  button-outline:
    backgroundColor: "{colors.surface}"
    textColor: "{colors.body}"
    rounded: "{rounded.option}"
    padding: "0.5rem 1rem"
  card:
    backgroundColor: "{colors.surface}"
    textColor: "{colors.ink}"
    rounded: "{rounded.card}"
    padding: "1.25rem"
  input:
    backgroundColor: "{colors.surface}"
    textColor: "{colors.ink}"
    rounded: "{rounded.option}"
    padding: "0.4rem 0.75rem"
---

# Design System: Magazijnuitleen

## Overview

**Creative North Star: "De Rustige Catalogus"** (voorstel — nog niet met het team bevestigd)

De UI is een leesbare catalogus, geen etalage. Rust overheerst: veel wit, dunne randen, één accentkleur die alleen op acties en selectie staat. De student scant een tabel of lijst en weet meteen wat er is; de magazijnier ziet dezelfde taal terug.

Het systeem leunt op Bootstrap 5 voor formulier- en knopbasis, met eigen tokens hierboven voor alles wat de magazijncontext specifiek maakt: voorraadstatussen, de vestigingskolommen en de materiaalkiezer.

**Let op:** het teamontwerp "CATALOGUS & AANVRAGEN" is zwart-wit met een kaartgrid. Deze implementatie is daar nog niet naar omgezet; dat is een openstaande richting, geen bevestigde afwijking.

**Key Characteristics:**
- Vlakke oppervlakken met 1px randen in plaats van schaduw.
- Blauw alleen voor actie, selectie en focus.
- Status altijd als tekst in een badge, nooit als kleur alleen.
- Tabellen voor overzicht, kaarten voor keuze en bevestiging.

## Colors

Koel blauw-grijs met één accent; kleur wordt spaarzaam gebruikt.

### Primary
- **Magazijnblauw** (`{colors.accent}`): primaire knop, selectierand, focusring. Nooit als grote vlakvulling.
- **Diep marine** (`{colors.navy-deep}`): paginakoppen en sectietitels.

### Neutral
- **Inkt** (`{colors.ink}`): labels en tabelkoppen.
- **Leesgrijs** (`{colors.body}`): secundaire tekst, omschrijvingen. Haalt 5.4:1 op alle gebruikte oppervlakken.
- **Papiervlak** (`{colors.surface}`): hoofdachtergrond van kaarten.
- **Koel vlak** (`{colors.surface-muted}`): overzichtsblokken, gekozen-materiaal, tabelkop.
- **Randgrijs** (`{colors.border}`): alle 1px-randen.

### Named Rules
**The One Accent Rule.** Blauw is voorbehouden aan iets wat je kunt doen of wat gekozen is. Staat het nergens op de pagina als actie, dan is het weg.

## Typography

**Display Font:** Helvetica Neue (met Helvetica, Arial, sans-serif)
**Body Font:** dezelfde stack — één familie voor alles.

**Character:** Zakelijk en neutraal, zoals een schoolsysteem hoort te lezen. Geen decoratieve koppen.

### Hierarchy
- **Heading** (700, clamp 1.6–2.2rem): paginakop, één per scherm.
- **Section title** (700, 1.15rem): blokken binnen een pagina ("1. Kies een materiaal").
- **Body** (400, 1rem, 1.5): lopende tekst, omschrijvingen, tabelinhoud.
- **Label** (600, 0.9rem): formulierlabels en filterlabels.
- **Table label** (700, 0.8rem, 0.03em, uppercase): kolomkoppen van de voorraadtabel.

## Layout

Tweekoloms pagina's (`1fr 1fr`) voor overzicht-plus-formulier, stapelend onder 900px; formuliervelden twee koloms, één kolom onder 560px. Overzichtskaarten en filters gebruiken `auto-fit`/`minmax` grids, dus geen vaste pixelbrij.

Ritme: 1.5rem tussen blokken, 1rem binnen blokken, 0.6–0.9rem tussen velden. De voorraadtabel scrollt horizontaal (`min-width: 720px`) in plaats van kolommen te proppen.

## Elevation & Depth

Geen schaduwen. Diepte komt van een 1px rand plus een iets donkerder vlak; hover licht het vlak op. Alles blijft plat, ook kaarten en het bevestigingsblok.

## Shapes

Zachte hoeken: kaarten 0.75rem, keuze-opties en invoervelden 0.6rem, badges volledig rond. Geen scherpe hoeken, geen pills voor knoppen.

## Components

### Buttons
- **Shape:** 0.6rem radius via Bootstrap.
- **Primary:** accentvulling, witte tekst, alleen voor de hoofdactie per blok.
- **Secondary:** witte vulling met rand, voor "Filters wissen" en "Terug naar overzicht".
- **Focus:** Bootstrap-focusring; eigen knoppen krijgen 2px accentoutline met 2px offset.

### Cards / Containers
- **Corner Style:** 0.75rem.
- **Background:** wit, of koel vlak voor samenvattingen.
- **Border:** 1px `{colors.border}`, geen schaduw.
- **Internal Padding:** 1–1.25rem.

### Inputs / Fields
- **Style:** witte vulling, 1px rand, 0.6rem radius, label erboven (nooit placeholder-als-label).
- **Focus:** accentkleurige rand plus focusring.
- **Error:** rode outline en rode tekst onder het veld via Bootstrap-validatie.

### Navigation
- **Style:** donkere zijbalk met icoon plus label; actieve pagina gemarkeerd door Bootstrap `active`.

### Voorraadbadge (signature)
Kleine pill met tekst "Op voorraad" / "Laag" / "Niet beschikbaar". Groen, amber, rood — maar de tekst draagt de betekenis. Drempel voor "Laag" is 2; dat is een open productbeslissing.

### Materiaalkiezer (signature)
Lijst met knoppen, twee regels per optie (naam, categorie) en de badge rechts. Geselecteerd = accentrand plus lichte vulling, plus `aria-pressed`.

## Do's and Don'ts

### Do:
- **Do** gebruik tekst bij elke status; kleur is extra, nooit de boodschap.
- **Do** houd secundaire tekst op `{colors.body}` of donkerder (WCAG AA).
- **Do** toon de vestiging altijd in de UI zodra voorraad ter sprake komt.
- **Do** laat elke knop een zichtbare focusstaat hebben.

### Don't:
- **Don't** schaduwen toevoegen; diepte is een rand.
- **Don't** blauw als decoratie gebruiken.
- **Don't** placeholder-tekst als enige label gebruiken.
- **Don't** een tweede accentkleur introduceren voor "iets belangrijks".
