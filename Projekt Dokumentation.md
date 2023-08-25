# Projekt-Dokumentation

### Diso-Bot: Julius Burlet, Timo Goedertier

| Datum | Version | Zusammenfassung                                              |
| ----- | ------- | ------------------------------------------------------------ |
|18.08.2023|0.0.1| Wir haben mit dem Projekt angefangen und den Bot erstellt und aufgesetzt.|
|25.08.2023|0.1.0| Der Bot funktioniert jetzt und hat schon seine ersten funktionen.|
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
| 11   |muss             |Qualität  |Der Bot benutzt das Zeichen <§> als Befehl anfang.|

### 1.3 Testfälle

| TC-№ | Ausgangslage | Eingabe | Erwartete Ausgabe |
| ---- | ------------ | ------- | ----------------- |
| 1.1  |Bot ist angeschalten|§g [random number]|Der Bot gibt eine Nachricht aus, die diese Eingabe als gültig bezeichnet.|
| 1.2  |Bot ist angeschalten|§g [random letter]|Bot gibt eine Nachricht aus, die diese Eingabe als ungültig bezeichnet.|
| 2.1  |Bot ist angeschalten|§highscorelsit|Der Bot gibt eine Rangliste mit den 10 Personen aus, die am meisten Punkte haben.|
| 3.1  |Bot ist angeschalten|§highscore [username]|Der Bot gibt eine Nachricht mit der Person und dessen Punkte aus.|
| 3.2  |Bot ist angeschalten|§highscore [invalid username]|Der Bot gibt eine Nachricht aus, die sagt, dass es den User nicht gibt.|
| 4.1  |Bot ist angeschalten|§playertwo [username]|Der Bot macht @[username] und sagt diesem, eine Zahl zwischen 1 und 100 auszuwählen.|
| 4.2  |Bot ist angeschalten|$number [number between 1 and 100]| Der Bot macht eine Ausgabe, die dem ersten Spieler sagt, dass er raten soll.|
| 5.1  |Bot ist angeschalten|§help|Der Bot gibt eine List an Befehlen aus.|
| 6.1  |Bot ist angeschalten|§g [zu grosse Zahl]|Der Bot gibt eine Nachricht aus, die dem User sagt das seine Zahl zu gross ist.|
| 7.1  |Bot ist angeschalten|§g [zu kleine Zahl]|Der Bot gibt eine Nachricht aus, die dem User sagt das seine Zahl zu klein ist.|
| 8.1  |Bot ist angeschalten|§g [korrekte Zahl]|Der Bot gibt eine Nachricht aus, die dem User sagt das er die Zahl erraten hat.|
| 10.1 |Bot ist angeschalten|-|Der User mit den meisten Punkten erhält die Rolle: [Best Guesser]|
| 11.1 |Bot ist angeschalten|Irgendein Befehl|Der Bot reagiert mit "[Emoji]".|
| 12.1 |Bot ist angeschalten|Irgend ein existierender Befehl mit §|Der Bot erkennt den Befehl und gibt die gewollte antwort aus.|
| 12.1 |Bot ist angeschalten|Irgend ein existierender Befehl mit falschem vorzeichen|Der Bot erkennt den Befehl nicht und macht nichts.|

### 1.4 Diagramme

![DiscordBotDiagramm drawio](https://github.com/timog06/LA_ILA2_1300/assets/110891995/7deb71c8-b36b-4fd6-b328-f5c11614bf31)


## 2 Planen

| AP-№ | Frist | Zuständig | Beschreibung | geplante Zeit |
| ---- | ----- | --------- | ------------ | ------------- |
| 1.A  |25.08.2023|Julius Burlet|Der Bot soll zufällige Zahlen generieren können, die dann vom User erraten werden kann.| 15' |
| 2.A  |01.09.2023|Timo Goedertier|Beim richtigen erraten einer Zahl wird dem User Punkte verliehen und auf dem User gespeichert.| 30' |
| 2.B  |01.09.2023|Timo Goedertier|Der Bot gibt eine Liste aus mit den 10 User im Server, die am meisten Punkte haben.| 25' |
| 3.A  |01.09.2023|Timo Goedertier|Der Bot gibt auf Behfel den Name des Users, der den Befehl eingegeben hat aus mit seiner Punkte Zahl.| 25' |
| 3.B  |01.09.2023|Timo Goedertier|Der Bot gibt auf Behfel den Name des gewählten Users aus mit seiner Punkte Zahl.| 15' |
| 4.A  |08.09.2023|Julius Burlet|Der Bot soll einen funktionierender 2-Spieler Modus haben.| 30' |
| 5.A  |25.08.2023|Timo Goedertier|Beim Eingeben des Befehls werden alle möglichen von diesem Bot in einer Liste gezeigt.| 30' |
| 6.A  |25.08.2023|Julius Burlet|Der Bot gibt ein Feedback, wenn die Zahl zu gross ist.| 10' |
| 7.A  |25.08.2023|Julius Burlet|Der Bot gibt ein Feedback, wenn die Zahl zu klein ist.| 10' |
| 8.A  |25.08.2023|Julius Burlet|Der Bot gibt ein Feedback, wenn die Zahl erraten wurde.| 10' |
| 9.A  |08.09.2023|Julius Burlet/Timo Goedertier|Das Design des Bots und seine Nachrichten sehen gut aus.| 30' |
| 10.A |01.09.2023|Timo Goedertier|Der Bot erstellt die gewollte Rolle, wenn er einem Server beitretet.| 20' |
| 10.B |01.09.2023|Timo Goedertier|Der Bot gibt dem Spieler mit den meisten Punkte die Rolle.| 35' |
| 11.A |08.09.2023|Julius Burlet|Alle Befehle des Bots fangen mit § an.| 5' |

## 3 Entscheiden

Wir haben uns entschieden, den Random Number Guesser als Discord Bot zu machen, damit wir eine einfachere Methode des Mehrspieler-Modus zu implementieren. Ausserdem, können verschiedene Spieler dadurch Kompetitiv gegeneinander antreten.

## 4 Realisieren

| AP-№ | Datum | Zuständig | geplante Zeit | tatsächliche Zeit |
| ---- | ----- | --------- | ------------- | ----------------- |
| 1.A  |25.08.2023|Julius Burlet| 15' | 10' |
| 2.A  |25.08.2023|Timo Goedertier| 30' | 45' |
| 2.B  |25.08.2023|Timo Goedertier| 25' | 15' |
| 3.A  |25.08.2023|Timo Goedertier| 15' | 20' |
| 6.A  |25.08.2023|Julius Burlet| 10' | 5' |
| 7.A  |25.08.2023|Julius Burlet| 10' | 5' |
| 8.A  |25.08.2023|Julius Burlet| 10' | 5' |


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
