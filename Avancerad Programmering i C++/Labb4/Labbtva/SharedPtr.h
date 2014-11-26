#include "RC.h"
#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>
#ifdef _DEBUG
#ifndef DBG_NEW
#define DBG_NEW new ( _NORMAL_BLOCK , __FILE__ , __LINE__ )
#define new DBG_NEW
#endif
#endif

template<typename C>
class SharedPtr{
private:
	C *heldPtr;
	RC* reference;
public:
	SharedPtr() : heldPtr(nullptr), reference(new RC()) 
	{
	};
	explicit SharedPtr(C* ptr) :heldPtr(ptr), reference(new RC())
	{
		if (ptr != nullptr)
		{
			reference->AddRef();
		}
	};
	SharedPtr(const SharedPtr<C>& otherPtr) : heldPtr(otherPtr.heldPtr), reference(otherPtr.reference)
	{
		if (otherPtr.heldPtr != nullptr)
		{
			reference->AddRef();
		}
	};
	C* get() const { return heldPtr; };
	void reset() 
	{
		int antal = reference->Release();
		if (antal <= 0)
		{
			if (heldPtr != nullptr)
			{
				delete heldPtr;
				heldPtr = nullptr;
			}
			if (reference != nullptr)
			{
				delete reference;
				reference = nullptr;
			}
		}
		else
		{
			heldPtr = nullptr;
		}
	};
	bool unique() const 
	{
		return reference->Count() == 1;
	};
	C& operator* ()
	{
		return *heldPtr;
	}

	C* operator-> ()
	{
		return heldPtr;
	}
	~SharedPtr()
	{
		int i = 0;
		//0038B828, 0x0038B7E8, 0x0038B428 
		if (reference != nullptr)
		{
			if (reference->Count() >= 0)
			{
				int antal = reference->Release();
				if (antal == 0)
				{
 					delete reference;
					reference = nullptr;
					if (heldPtr != nullptr)
					{
						delete heldPtr;
						heldPtr = nullptr;
					}
				}
				else if (antal == -1)
				{
					delete reference;
					reference = nullptr;
					delete heldPtr;
				}
			}
		}
		int j = 0;
	}
	bool operator!()
	{
		return heldPtr == nullptr;
	}
	bool operator==(const SharedPtr<C>& a) const
	{
		return heldPtr == a.heldPtr;
	}
	bool operator==(const C* ptr)
	{
		return this->heldPtr == ptr;
	}
	bool operator<(const SharedPtr<C>& s) 
	{
		return this->reference->Count() < s.reference->Count();
	}
	SharedPtr<C>& operator = (const SharedPtr<C>& sp)
	{
		// Assignment operator
		if (this != &sp) // Avoid self assignment
		{
			// Decrement the old reference count
			// if reference become zero delete the old data
			if (reference->Release() == 0)
			{
				delete heldPtr;
				delete reference;
			}

			// Copy the data and reference pointer
			// and increment the reference count
			heldPtr = sp.heldPtr;
			reference = sp.reference;
			reference->AddRef();
		}
		return *this;
	}
};