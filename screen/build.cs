// Builds either a vertical or horizontal brick screen.
function buildPxSysScreen ( %data, %pos, %angleID, %color, %isVertical )
{
	if ( $PxSys::HasBrickScreen )
	{
		return;
	}

	if ( %data $= "" )
	{
		%data = brick1x1PrintData;
	}

	if ( !isObject (%data) )
	{
		error ("buildPxSysScreen () - Datablock does not exist!");
		return;
	}

	if ( %angleID < 0  ||  %angleID > 3 )
	{
		error ("buildPxSysScreen () - Invalid angleID");
		return;
	}

	if ( $PxSys::Screen::Width $= ""  ||  $PxSys::Screen::Height $= "" )
	{
		error ("buildPxSysScreen () - Please set the width and height before building!");
		return;
	}

	PxSys_deleteAllPixels (true);

	if ( %isVertical $= "" )
	{
		%isVertical = true;
	}

	%posX = getWord (%pos, 0);
	%posY = getWord (%pos, 1);
	%posZ = getWord (%pos, 2);

	%width  = $PxSys::Screen::Width;
	%height = $PxSys::Screen::Height;

	%sizeX = %data.brickSizeX;
	%sizeY = %data.brickSizeY;
	%sizeZ = %data.brickSizeZ;

	%sizeMulX = brickToMetric (%sizeX);
	%sizeMulY = brickToMetric (%sizeY);
	%sizeMulZ = plateToMetric (%sizeZ);

	%group = $PxSys::Screen::BrickGroup;

	for ( %x = 0;  %x < %width;  %x++ )
	{
		for ( %y = 0;  %y < %height;  %y++ )
		{
			%centeredX = %x - (%width / 2);
			%centeredY = %y - (%height / 2);

			if ( %isVertical )
			{
				%centeredY = 0;
			}

			%brickX = %posX + (%centeredX * %sizeMulX);
			%brickY = %posY + (%centeredY * %sizeMulY);
			%brickZ = %posZ;

			// Positioning fixes
			if ( %isVertical )
			{
				// Since we're building vertically, start at the top and build down.
				// That way 0,0 is in its correct position in the top left corner.
				%brickZ += %height * %sizeMulZ;
				%brickZ -= %y * %sizeMulZ;

				// Minor adjustment to align it with the Z coordinate properly.
				%brickZ -= %sizeMulZ / 2;
			}
			else
			{
				// Invert the Y coordinate so the screen isn't mirrored.
				%brickY = -%brickY;
			}

			%brickPos = vector2DRotateDeg (%brickX SPC %brickY, angleIDToDeg (%angleID));
			%brickPos = %brickPos SPC %brickZ;

			%brick = PxSys_createBrick (%data, %brickPos, %angleID, %color, true, %group, true, true);

			if ( !isObject (%brick) )
			{
				error ("buildPxSysScreen () - Brick could not be planted at " @ %brickPos);
				continue;
			}

			PxSys_setPixel (%x, %y, %brick);
		}
	}

	$PxSys::HasBrickScreen = true;
}
