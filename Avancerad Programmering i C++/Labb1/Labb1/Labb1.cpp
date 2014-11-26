// Labb1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <assert.h>
#include "List.h"
#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>
#ifdef _DEBUG
#ifndef DBG_NEW
#define DBG_NEW new ( _NORMAL_BLOCK , __FILE__ , __LINE__ )
#define new DBG_NEW
#endif
#endif


int main()
{
	_CrtDumpMemoryLeaks();
	List<float> myList;
	assert(myList.Check(0));
	myList.push_back(3.4f);
	assert(myList.Check(1));
	myList.push_back(3.5f);
 	assert(myList.Check(2));
	myList.First()->InsertBefore(&myList, 2.5f);
	myList.pop_back();
	myList.pop_back();
	myList.pop_back();
	myList.pop_back();
	assert(myList.Check(0));
	myList.push_front(3.5f);
	myList.push_front(3.4f);
	myList.pop_front();
	assert(myList.Check(1));
	myList.pop_front();
	assert(myList.Check(0));
	myList.push_front(3.5f);
	myList.push_front(2.2f);
	myList.push_front(3.5f);
	myList.push_front(2.2f);
};

