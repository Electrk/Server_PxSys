function PxSys_createBrick ( %data, %pos, %angID, %color, %plant, %brickGroup, %ignoreStuck, %ignoreFloat )
{
	switch ( %angID )
	{
		case 0: %rotation = "1 0 0 0";
		case 1: %rotation = "0 0 1 90.0002";
		case 2: %rotation = "0 0 1 180";
		case 3: %rotation = "0 0 -1 90.0002";

		default:
			error ("PxSys_createBrick () - Invalid angleID " @ %angleID);
			return 0;
	}

	if ( %brickGroup $= "" )
	{
		%brickGroup = BrickGroup_888888;
	}
	else if ( !isObject (%brickGroup) )
	{
		error ("PxSys_createBrick () - Brick group does not exist!");
		return 0;
	}

	%brick = new fxDTSBrick ()
	{
		dataBlock = %data;

		position = %pos;
		rotation = %rotation;
		angleID  = %angID;

		colorID = %color;

		isPlanted = %plant;
	};

	%brickGroup.add (%brick);

	if ( isObject (%brickGroup.client) )
	{
		%brick.client = %brickGroup.client;
	}
	
	if ( %plant )
	{
		%error = %brick.plant ();

		if ( (%error == 1  &&  !%ignoreStuck)  ||  (%error == 2  &&  !%ignoreFloat)  ||  %error >= 3 )
		{
			%brick.delete ();
			return 0;
		}

		%brick.onPlant ();
		%brick.setTrusted (true);
	}

	return %brick;
}
