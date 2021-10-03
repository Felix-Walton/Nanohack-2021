#define echoPin 7
#define trigPin 8


long duration;
int distance;
int dista;
int distan;


void setup() {
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
  Serial.begin(9600);
  Serial.println("Ultrasonic Sensor Test");
}
void dist(){
  digitalWrite(trigPin, LOW);
  delayMicroseconds(10);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(20);
  digitalWrite(trigPin, LOW);
 
  duration = pulseIn(echoPin, HIGH);
  distance = duration * 0.34 /2;

  if(distance<1000){
    dista = distance;
  }
  }
void loop() {
  for (int i=1; i<=5; i++){
  dist();
  dista+=distance;
  }
  distan = dista/5;
 
  Serial.println(distan);
  }
