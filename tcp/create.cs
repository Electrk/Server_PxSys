function createPxSysTCP ( %isServerTCP, %port, %address, %connectOnCreated )
{
	if ( %isServerTCP  &&  !isObject (MissionCleanup) )
	{
		error ('createPxSysTCP () - MissionCleanup does not exist!');
		return 0;
	}

	if ( %port $= "" )
	{
		error ("createPxSysTCP () - Port is required!");
		return 0;
	}

	if ( %address $= "" )
	{
		error ("createPxSysTCP () - Address is required!");
		return 0;
	}

	%tcp = new TCPObject (PxSysTCP);

	%tcp.port        = %port;
	%tcp.address     = %address;
	%tcp.isServerTCP = defaultValue (%isServerTCP, false);

	if ( %tcp.isServerTCP )
	{
		MissionCleanup.add (%tcp);
	}

	if ( %connectOnCreated )
	{
		%tcp.connect (%address @ ":" @ %port);
	}

	return %tcp;
}

function PxSysTCP::onAdd ( %this )
{
	// Callback
}

function PxSysTCP::onRemove ( %this )
{
	PxSys_deleteAllPixels ();
}
