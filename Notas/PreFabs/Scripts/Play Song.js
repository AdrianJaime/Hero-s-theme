#pragma strict
var Redobject : GameObject;
var Blueobject : GameObject;
var Greenobject : GameObject;
var Yellowobject : GameObject;

function Awake () {
//SongStart
SongStart();
}

function SongStart()
{
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.69, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Blueobject, transform.position + Vector3(-0.49, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.2);
Instantiate(Greenobject, transform.position + Vector3(0.71, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Yellowobject, transform.position + Vector3(1.81, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Song1();

}

function Song1()
{
yield WaitForSeconds (.8);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.8);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.8);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.8);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.8);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.6);
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.6);
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.6);
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.6);
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.6);
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.4);
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.4);
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.4);
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.4);
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.4);
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.4);
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.2);
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.2);
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.2);
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.2);
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Song2();
}

function Song2()
{
yield WaitForSeconds (.5);
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.3);
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.3);
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Song3();
}

function Song3()
{
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Song4();
}

function Song4()
{
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.2);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.3);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.2);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.3);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.7);
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.3);
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.3);
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.6);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.6);
SongEnd();
}

function SongEnd()
{
yield WaitForSeconds (.5);
Instantiate(Redobject, transform.position + Vector3(-1.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Blueobject, transform.position + Vector3(-0.509913, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.2);
Instantiate(Greenobject, transform.position + Vector3(0.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
Instantiate(Yellowobject, transform.position + Vector3(1.490087, 3.846249, 0), Quaternion.Euler(0,0,0) );
yield WaitForSeconds (.5);
}
