# Support_PxSys
> A client for PxSys that renders pixel data on bricks.


Lets you create a brick screen that receives data from PxSys server.


## Usage

Here is a bare-bones setup example:

```js
// Initialize PxSys screen data
initPxSysScreen ("My Application's Name", 1, BrickGroup_12949);
// Create and connect a TCPObject to 127.0.0.1:23
createPxSysTCP (23, "127.0.0.1", true);

package MyPackage
{
	// We want to parent PxSys_setSize before we build our screen because
	// it won't build unless we have a width and a height set.

	// The add-on doesn't do this automatically to give users full control of
	// when and where they build their brick screen.
	function PxSys_setSize ( %width, %height )
	{
		Parent::PxSys_setSize (%width, %height);
		buildPxSysScreen ();
	}
};
activatePackage (MyPackage);

```

You can then send commands with the `PxSysTCP::sendCommand` method.

**Example:** `PxSysTCP.sendCommand ("CL_MY_TEST_COMMAND", "argument #1", "arg2", -55, "etc.");`



## API


#### `initPxSysScreen ([appName, appVersion, brickGroup]);`

Initialize PxSys data.

| Argument | Defaults to: |
| -------- | ------------ |
| appName  | "My Application" |
| appVersion | 1 |
| brickGroup | BrickGroup_888888 |


#### `createPxSysTCP (port, address[, connectOnCreated]);`

Create the `PxSysTCP` object.  Used to communicate with the server it's connected to.  If `connectOnCreated` is true, `PxSysTCP` will attempt to connect to the server immediately upon creation.


#### `PxSysTCP::connectToServer ();`

Pretty self-explanatory.  Connects the `PxSysTCP` object to the server.


#### `PxSysTCP::sendCommand (command[, arg1, arg2, ..., arg12]);`

Sends a client command to the server with up to 12 arguments.


#### `buildPxSysScreen ([brickDataBlock, position, angleID, colorID, isVertical]);`

Builds a brick screen out of `brickDataBlock` bricks at `position`.

You cannot build a screen without having set the width and the height, nor can you build one when one has already been built (`$PxSys::HasBrickScreen`).

| Argument | Description |
| -------- | ------------ |
| brickDataBlock  | The brick datablock to build the screen with. |
| position | Origin is center of the screen, and, if it's a vertical screen, at the bottom. |
| angleID | What angle the screen is built at (0–3 like for bricks). |
| colorID | The starting colorID of each brick. |
| isVertical | If `true`, build vertically up on the Z axis.  If `false`, built horizontally across the Y axis. |


#### `PxSys_setPixel (x, y, object);`

Sets the pixel object at (x, y).  You can also use `$PxSys_[x, y] = object;` for much faster results.


#### `PxSys_getPixel (x, y);`

Returns the pixel object at (x, y).  You can also use `$PxSys_[x, y]` for much faster results.


#### `PxSys_deleteAllPixels ();`

Deletes all pixel objects in the screen.  Resets `$PxSys::HasBrickScreen` back to `false` so another brick screen can be built.


## Global Variables

Here are some global variables that you can use:

| Variable | Description |
| -------- | ------------ |
| $PxSys::Version | The version of PxSys we're using.  **(read only - do not modify)** |
| $PxSys::HasBrickScreen | Whether or not a brick screen has already been built.  **(read only - do not modify)** |
| $PxSys::Screen::Width | The width of the screen.  **(read only - do not modify)** |
| $PxSys::Screen::Height | The height of the screen.  **(read only - do not modify)**  |
| $PxSys::Screen::AppName | The name of your PxSys application. |
| $PxSys::Screen::AppVersion | The version of your PxSys application. |
| $PxSys::Screen::BrickGroup | The brick group we put all the screen bricks into. |


## Additional Information

This add-on is to be used in conjunction with the [pxsys-server](https://npmjs.org/package/pxsys-server) npm package.

There are also special color prints available for sharper color changes, since changing a brick's print doesn't fade like changing its color does.  This is the `colorPrintID` field.  [Here is the default pack](https://github.com/Electrk/Print_PxSys_Default) of colors.
