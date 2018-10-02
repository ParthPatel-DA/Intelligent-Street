int aPin = A4;
int led1 = 12;
int led0 = 13;
int led2 = 2;
int led3 = 7;
int led4 = 4;
int sv = 0;
int IR1 = A0;
int IR2 = A1;
int IR3 = A2;
int IR4 = A3;
int a = 0;
int b = 0;
int c = 0;
int d = 0;
unsigned long t1=0,t2=0,t3=0,t4=0;
bool f1=false,f2=false,f3=false,f4=false;

void setup() {
    // put your setup code here, to run once:
    Serial.begin(9600);
    pinMode(led1, OUTPUT); // set port 12 as output
    pinMode(led0, OUTPUT); // set port 13 as output
    pinMode(led2, OUTPUT); // set port 2 as output
    pinMode(led3, OUTPUT); // set port 7 as output
    pinMode(led4, OUTPUT); // set port 4 as output
    pinMode(IR1, INPUT); // set port A0 as output
    pinMode(IR2, INPUT); // set port A1 as output
    pinMode(IR3, INPUT); // set port A2 as output
    pinMode(IR4, INPUT); // set port A3 as output
    b=1;
}

void loop() {
    // put your main code here, to run repeatedly:
    sv = analogRead(aPin); 
    if (sv < 750) { // check Day or night
        digitalWrite(led0, HIGH);
        digitalWrite(led4, b);
        int value = analogRead(IR1); // get value of first IR sensor value
        if (value < 700) // check object passing or not
        {
            a = 1;
            b = 1;
            f1=true; // set flag for first IR sensor
            digitalWrite(led4, b); // turn on 2 LED
            digitalWrite(led1, a); // turn on 3 LED
        }
        else{
            if(f1==true){
                t1=millis(); // store time of object passed from first IR sensor
                f1=false; // unset flag for first IR sensor
            }
        }

        value = analogRead(IR2); // get value of second IR sensor value
        if (value < 600) // check object passing or not
        {
            c=1;
            f2=true; // set flag for second IR sensor
            digitalWrite(led2, c); // turn on 4 LED
        }
        else{
            if(f2==true){
                t2=millis(); // store time of object passed from second IR sensor
                f2=false; // unset flag for second IR sensor
                Serial.print("Speed : ");
                Serial.println((0.03/((t2-t1)/1000000))*3.6); // find speed of vehicle from first IR sensor to second
            }
        }

        value = analogRead(IR3); // get value of third IR sensor value
        if (value < 700) // check object passing or not
        {
            b = 0;
            d = 1;
            f3=true; // set flag for third IR sensor
            digitalWrite(led3, d); // turn on 5-6 LED
            digitalWrite(led4, b); // turn off 2 LED
        }
        else{
            if(f3==true){
                t3=millis(); // store time of object passed from third IR sensor
                f3=false; // unset flag for third IR sensor
                Serial.print("Speed : ");
                Serial.println((0.03/((t3-t2)/1000000))*3.6); // find speed of vehicle from second IR sensor to third
            }
        }

        value = analogRead(IR4); // get value of fourth IR sensor value
        if (value < 700) // check object passing or not
        {
            a = 0;
            d = 1;
            f4=true; // set flag for fourth IR sensor
            digitalWrite(led1, a); // turn off 3 LED
            digitalWrite(led3, d); // turn on 5-6 LED
        }
        else{
            if(f4==true){
                t4=millis(); // store time of object passed from fourth IR sensor
                f4=false; // unset flag for fourth IR sensor
                Serial.print("Speed : ");
                Serial.println((0.03/((t4-t3)/1000000))*3.6); // find speed of vehicle from third IR sensor to fourth
            }
        }
    }
    else {
        digitalWrite(led1, LOW);
        digitalWrite(led2, LOW);
        digitalWrite(led3, LOW);
        digitalWrite(led0, LOW);
        digitalWrite(led4, LOW);
    }
}
