$Const::BrickStudSize  = 0.5;
$Const::BrickPlateSize = 0.2;

// ------------------------------------------------

function PxSys_messageAll ( %message )
{
	messageAll ('', "\c4[PxSys] \c6" @ %message);
}

// ------------------------------------------------


function defaultValue ( %value, %defaultValue )
{
	if ( %value $= "" )
	{
		return %defaultValue;
	}

	return %value;
}


// ------------------------------------------------

function brickToMetric ( %number )
{
	return %number * $Const::BrickStudSize;
}

function metricToBrick ( %number )
{
	return %number / $Const::BrickStudSize;
}

function plateToMetric ( %number )
{
	return %number * $Const::BrickPlateSize;
}

function metricToPlate ( %number )
{
	return %number / $Const::BrickPlateSize;
}

// ------------------------------------------------


function vector2DRotate ( %vector, %radians )
{
	%x = getWord (%vector, 0);
	%y = getWord (%vector, 1);

	%xn = (%x * mCos (%radians)) - (%y * mSin (%radians));
	%yn = (%x * mSin (%radians)) + (%y * mCos (%radians));

	return %xn SPC %yn;
}

function vector2DRotateDeg ( %vector, %degrees )
{
	return vector2DRotate (%vector, mDegToRad (%degrees));
}

function angleIDToDeg ( %angleID )
{
	switch ( %angleID )
	{
		case 0: return 0;
		case 1: return 270;
		case 2: return 180;
		case 3: return 90;
	}

	error ("angleIDToDeg () - Invalid angleID " @ %angleID);
	return 0;
}
