// -------------------------------------------------
// Copyright (c) 2022 HiBit <https://www.hibit.dev>
// -------------------------------------------------

#define NOTE_B0  31
#define NOTE_C1  33
#define NOTE_CS1 35
#define NOTE_D1  37
#define NOTE_DS1 39
#define NOTE_E1  41
#define NOTE_F1  44
#define NOTE_FS1 46
#define NOTE_G1  49
#define NOTE_GS1 52
#define NOTE_A1  55
#define NOTE_AS1 58
#define NOTE_B1  62
#define NOTE_C2  65
#define NOTE_CS2 69
#define NOTE_D2  73
#define NOTE_DS2 78
#define NOTE_E2  82
#define NOTE_F2  87
#define NOTE_FS2 93
#define NOTE_G2  98
#define NOTE_GS2 104
#define NOTE_A2  110
#define NOTE_AS2 117
#define NOTE_B2  123
#define NOTE_C3  131
#define NOTE_CS3 139
#define NOTE_D3  147
#define NOTE_DS3 156
#define NOTE_E3  165
#define NOTE_F3  175
#define NOTE_FS3 185
#define NOTE_G3  196
#define NOTE_GS3 208
#define NOTE_A3  220
#define NOTE_AS3 233
#define NOTE_B3  247
#define NOTE_C4  262
#define NOTE_CS4 277
#define NOTE_D4  294
#define NOTE_DS4 311
#define NOTE_E4  330
#define NOTE_F4  349
#define NOTE_FS4 370
#define NOTE_G4  392
#define NOTE_GS4 415
#define NOTE_A4  440
#define NOTE_AS4 466
#define NOTE_B4  494
#define NOTE_C5  523
#define NOTE_CS5 554
#define NOTE_D5  587
#define NOTE_DS5 622
#define NOTE_E5  659
#define NOTE_F5  698
#define NOTE_FS5 740
#define NOTE_G5  784
#define NOTE_GS5 831
#define NOTE_A5  880
#define NOTE_AS5 932
#define NOTE_B5  988
#define NOTE_C6  1047
#define NOTE_CS6 1109
#define NOTE_D6  1175
#define NOTE_DS6 1245
#define NOTE_E6  1319
#define NOTE_F6  1397
#define NOTE_FS6 1480
#define NOTE_G6  1568
#define NOTE_GS6 1661
#define NOTE_A6  1760
#define NOTE_AS6 1865
#define NOTE_B6  1976
#define NOTE_C7  2093
#define NOTE_CS7 2217
#define NOTE_D7  2349
#define NOTE_DS7 2489
#define NOTE_E7  2637
#define NOTE_F7  2794
#define NOTE_FS7 2960
#define NOTE_G7  3136
#define NOTE_GS7 3322
#define NOTE_A7  3520
#define NOTE_AS7 3729
#define NOTE_B7  3951
#define NOTE_C8  4186
#define NOTE_CS8 4435
#define NOTE_D8  4699
#define NOTE_DS8 4978
#define REST     0

#define BUZZER_PIN 9
#define LED_PIN 4 // Definimos el pin para el LED, puedes cambiarlo (por ejemplo, a 2, 3, 4, etc.)

int melody[] = {
  NOTE_E5, NOTE_D5, NOTE_FS4, NOTE_GS4,
  NOTE_CS5, NOTE_B4, NOTE_D4, NOTE_E4,
  NOTE_B4, NOTE_A4, NOTE_CS4, NOTE_E4,
  NOTE_A4
};

int durations[] = {
  8, 8, 4, 4,
  8, 8, 4, 4,
  8, 8, 4, 4,
  2
};

bool playingMelody = false; // Variable para controlar si la melodía está sonando
int currentNoteIndex = 0; // Para llevar la cuenta de la nota actual

void setup()
{
  pinMode(BUZZER_PIN, OUTPUT);
  pinMode(LED_PIN, OUTPUT);
  Serial.begin(9600); // Inicializa la comunicación serial a 9600 baudios
}

void loop()
{
  // ----------------------------------------
  // Manejo de la comunicación serial (RECEPCIÓN)
  // ----------------------------------------
  if (Serial.available() > 0) {
    char command = Serial.read(); // Lee el byte entrante

    if (command == 'P') { // 'P' de Play (Reproducir)
      playingMelody = true;
      currentNoteIndex = 0; // Reinicia la melodía al iniciar
      Serial.println("Melody started"); // Envía confirmación a C#
    } else if (command == 'S') { // 'S' de Stop (Detener)
      playingMelody = false;
      noTone(BUZZER_PIN);
      digitalWrite(LED_PIN, LOW);
      Serial.println("Melody stopped"); // Envía confirmación a C#
    }
  }

  // ----------------------------------------
  // Lógica de reproducción de melodía y LED
  // ----------------------------------------
  if (playingMelody) {
    int size = sizeof(durations) / sizeof(int);

    // Asegurarse de que el índice no se salga del rango
    if (currentNoteIndex >= size) {
      currentNoteIndex = 0; // Reiniciar la melodía
      // Si quieres que la melodía se detenga al terminar, descomenta la línea de abajo:
      // playingMelody = false;
      // Serial.println("Melody finished");
    }

    int note = currentNoteIndex; // Usamos el índice actual

    int noteDuration = 1000 / durations[note];

    // Si es un "descanso" (REST), no reproducimos sonido ni encendemos el LED
    if (melody[note] == REST) {
      noTone(BUZZER_PIN);
      digitalWrite(LED_PIN, LOW);
    } else {
      digitalWrite(LED_PIN, HIGH);
      tone(BUZZER_PIN, melody[note], noteDuration);
    }

    // Enviamos la nota actual a C#
    Serial.print("Note:");
    Serial.println(melody[note]); // Envía la frecuencia de la nota

    int ledOnDuration = noteDuration * 0.9;
    delay(ledOnDuration);

    digitalWrite(LED_PIN, LOW);
    noTone(BUZZER_PIN);

    int pauseAfterLedOff = noteDuration - ledOnDuration;
    int pauseBetweenNotes = (1000 / durations[note]) * 0.30;

    delay(pauseAfterLedOff + pauseBetweenNotes);

    currentNoteIndex++; // Avanzamos a la siguiente nota
  } else {
    // Si la melodía no está activa, podemos poner un pequeño delay
    // para evitar que el loop se ejecute demasiado rápido sin hacer nada.
    delay(10);
  }
}