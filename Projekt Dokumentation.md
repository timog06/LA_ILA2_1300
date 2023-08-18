# Projekt-Dokumentation

### Diso-Bot: Julius Burlet, Timo Goedertier

| Datum | Version | Zusammenfassung                                              |
| ----- | ------- | ------------------------------------------------------------ |
|18.08.2023|0.0.1| Wir haben mit dem Projekt angefangen und den Bot erstellt und aufgesetzt.|
||||
||||

## 1 Informieren

### 1.1 Ihr Projekt

Dies ist ein Randomnumberguesser bot für Discord. Mit diversen kleinen features.

### 1.2 User Stories

| US-№ | Verbindlichkeit | Typ  | Beschreibung                       |
| ---- | --------------- | ---- | ---------------------------------- |
| 1    |muss             |Funktional|Als ein User möchte ich zufällige Zahlen erraten können.|
| 2    |muss             |Funktional|Als ein User möchte ich, dass es eine Highscore-Liste gibt.|
| 3    |kann             |Funktional|Als ein User möchte ich, dass ich meinen eigenen Highscore anzeigen lassen kann.|
| 4    |muss             |Funktional|Als ein User möchte ich einen Zwei-Spieler Modus.|
| 5    |muss             |Funktional|Als ein user möchte ich einen Befehl eingeben um alle möglichen Befehle ersichtlich zu sehen.|
| 6    |muss             |Funktional|Als User möchte ich ein Feedback, wenn meine Zahl zu gross ist.|
| 7    |muss             |Funktional|Als User möchte ich ein Feedback, wenn meine Zahl zu klein ist.|
| 8    |muss             |Funktional|Als ein User möchte ich ein Feedback, wenn ich die Zahl erraten habe.|
| 9    |kann             |Qualität  |Als ein User möchte ich, dass die Nachrichten vom Bot schön aussehen.|
| 10   |kann             |Rand      |Als ein User möchte ich eine Rolle haben, wenn ich den höchsten highscore habe.|
| 11   |kann             |Rand      |Als ein User möchte ich, das der Bot auch Emojii-Reaktionen als Rückmeldung benutzt.|
| 12   |muss             |Qualität  |Der Bot benutzt das Zeichen <§> als Befehl anfang.|

### 1.3 Testfälle

| TC-№ | Ausgangslage | Eingabe | Erwartete Ausgabe |
| ---- | ------------ | ------- | ----------------- |
| 1.1  |Bot ist angeschalten|§g [random number]|Der Bot gibt eine Nachricht aus, die diese Eingabe als gültig bezeichnet.|
| 1.2  |Bot ist angeschalten|§g [random letter]|Bot gibt eine Nachricht aus, die diese Eingabe als ungültig bezeichnet.|
| 2.1  |Bot ist angeschalten|§highscorelsit|Der Bot gibt eine Rangliste mit den 10 Personen aus, die am meisten Punkte haben.|
| 3.1  |Bot ist angeschalten|§highscore [username]|Der Bot gibt eine Nachricht mit der Person und dessen Punkte aus.|
| 3.2  |Bot ist angeschalten|§highscore [invalid username]|Der Bot gibt eine Nachricht aus, die sagt, dass es den User nicht gibt.|
|!4.1! |Bot ist angeschalten|§playertwo [username]|Der Bot macht @[username] und sagt diesem, eine Zahl zwischen 1 und 100 auszuwählen.|
| 5.1  |Bot ist angeschalten|§help|Der Bot gibt eine List an Befehlen aus.|
| 6.1  |Bot ist angeschalten|§g [zu grosse Zahl]|Der Bot gibt eine Nachricht aus, die dem User sagt das seine Zahl zu gross ist.|
| 7.1  |Bot ist angeschalten|§g [zu kleine Zahl]|Der Bot gibt eine Nachricht aus, die dem User sagt das seine Zahl zu klein ist.|
| 8.1  |Bot ist angeschalten|§g [korrekte Zahl]|Der Bot gibt eine Nachricht aus, die dem User sagt das er die Zahl erraten hat.|
| 10.1 |Bot ist angeschalten|-|Der User mit den meisten Punkten erhält die Rolle: [Best Guesser]|
| 11.1 |Bot ist angeschalten|Irgendein Befehl|Der Bot reagiert mit "[Emoji]".|
| 12.1 |Bot ist angeschalten|Irgend ein existierender Befehl mit §|Der Bot erkennt den Befehl und gibt die gewollte antwort aus.|
| 12.1 |Bot ist angeschalten|Irgend ein existierender Befehl mit falschem vorzeichen|Der Bot erkennt den Befehl nicht und macht nichts.|

### 1.4 Diagramme

✍️ Hier können Sie PAPs, Use Case- und Gantt-Diagramme oder Ähnliches einfügen.

## 2 Planen

| AP-№ | Frist | Zuständig | Beschreibung | geplante Zeit |
| ---- | ----- | --------- | ------------ | ------------- |
| 1.A  |       |           |              |               |
| ...  |       |           |              |               |

Total: 

✍️ Die Nummer hat das Format `N.m`, wobei `N` die Nummer der User Story ist, auf die sich das Arbeitspaket bezieht, und `m` von `A` an nach oben buchstabiert. Beispiel: Das dritte Arbeitspaket, das die zweite User Story betrifft, hat also die Nummer `2.C`.

✍️ Ein Arbeitspaket sollte etwa 45' für eine Person in Anspruch nehmen. Die totale Anzahl Arbeitspakete sollte etwa Folgendem entsprechen: `Anzahl R-Sitzungen` ╳ `Anzahl Gruppenmitglieder` ╳ `4`. Wenn Sie also zu dritt an einem Projekt arbeiten, für welches zwei R-Sitzungen geplant sind, sollten Sie auf `2` ╳ `3` ╳`4` = `24` Arbeitspakete kommen. Sollten Sie merken, dass Sie hier nicht genügend Arbeitspakte haben, denken Sie sich weitere "Kann"-User Stories für Kapitel 1.2 aus.

## 3 Entscheiden

✍️ Dokumentieren Sie hier Ihre Entscheidungen und Annahmen, die Sie im Bezug auf Ihre User Stories und die Implementierung getroffen haben.

## 4 Realisieren

| AP-№ | Datum | Zuständig | geplante Zeit | tatsächliche Zeit |
| ---- | ----- | --------- | ------------- | ----------------- |
| 1.A  |       |           |               |                   |
| ...  |       |           |               |                   |

### 4.1 Quellen

Das Skelet, des Bots haben wir von hier: https://moodle.bbbaden.ch/mod/resource/view.php?id=132758

## 5 Kontrollieren

### 5.1 Testprotokoll

| TC-№ | Datum | Resultat | Tester |
| ---- | ----- | -------- | ------ |
| 1.1  |       |          |        |
| ...  |       |          |        |

✍️ Vergessen Sie nicht, ein Fazit hinzuzufügen, welches das Test-Ergebnis einordnet.

### 5.2 Exploratives Testen

| BR-№ | Ausgangslage | Eingabe | Erwartete Ausgabe | Tatsächliche Ausgabe |
| ---- | ------------ | ------- | ----------------- | -------------------- |
| I    |              |         |                   |                      |
| ...  |              |         |                   |                      |

✍️ Verwenden Sie römische Ziffern für Ihre Bug Reports, also I, II, III, IV etc.

## 6 Auswerten

✍️ Fügen Sie hier eine Verknüpfung zu Ihrem Lern-Bericht ein.
