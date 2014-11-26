class RC
{
private:
	int count; // Reference count

public:
	void AddRef()
	{
		// Increment the reference count
		count++;
	}

	int Release()
	{
		// Decrement the reference count and
		// return the reference count.
		return --count;
	}
	int Count()
	{
		return count;
	}
};