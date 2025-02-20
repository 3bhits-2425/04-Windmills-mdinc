# 04-Windmills-mdinc
# 🎯 Lernziele: Windmühlen-Projekt in Unity

## 🏗 **Grundlagen von GameObjects und Hierarchie**
- [x] **Whiteboxing mit Primitives**: Erstellen einer einfachen Windmühle aus grundlegenden Formen (Cubes, Cylinders).
- [x] **Pivot-Punkt setzen**: Das Windrad als **Kind-Objekt** eines leeren GameObjects anlegen, um die Drehung korrekt zu steuern.

## 🔄 **Transformation & Bewegung in Unity**
- [x] **Rotation mit `transform.Rotate`**: Wie sich ein Objekt um eine Achse dreht.
- [x] **Verstehen von `Time.deltaTime`**: Warum es für flüssige Bewegungen genutzt wird.

## 🎮 **Benutzerinteraktion & Steuerung**
- [x] **Tasteneingabe (`Input.GetKey`)**: 
  - [x] Space-Taste gedrückt halten = Beschleunigung.
  - [x] Space-Taste loslassen = Verlangsamung.
- [x] **Mehrere Windmühlen unabhängig steuerbar machen**: Nur das aktuell ausgewählte Windrad soll auf `Space` reagieren.

## 🖥 **UI-Elemente & Visualisierung von Variablen**
- [ ] **Einbindung eines `Slider`-Elements**: Anzeige der aktuellen Geschwindigkeit (0–255).
- [x] **Werteskalierung (`Mathf.Lerp`)**: Geschwindigkeit in eine Lichtintensität umwandeln.

## 🏗 **Mehrere Objekte verwalten & Interaktion zwischen Objekten**
- [x] **Mehrere Windmühlen in einer Szene**: Jede hat eigene Steuerung, aber dasselbe Skript.
- [ ] **Unterschiedliche Zustände pro Windmühle**: Eine ist aktiv steuerbar, andere nicht.
- [ ] **UML DIAGRAMM**
      ![image](https://github.com/user-attachments/assets/1619ca45-1e6c-488e-ac22-aa71cbeead85)

