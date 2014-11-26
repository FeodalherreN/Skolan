#define _CRTDBG_MAP_ALLOC
#ifdef _DEBUG
#ifndef DBG_NEW
#define DBG_NEW new ( _NORMAL_BLOCK , __FILE__ , __LINE__ )
#define new DBG_NEW
#endif
#endif  // _DEBUG
#include "stdafx.h"
#include <stdlib.h>
#include <crtdbg.h>

#include "String.h"

#include <string>
#include <iostream>
#include <cassert>
#include <utility>
using namespace std;


void TestF�rGodk�ntString() {
	//-	String()
	String s0;	assert(s0 == "");

	//-	String(Str�ng str�ng)
	String s1("foo"); assert(s1 == "foo");
	String s2(s1); assert(s2 == "foo");
	String s3("bar");  assert(s3 == "bar");

	//-	~String() Kom ih�g destruktorn!
	delete new String("hej");

	//	-	operator =(Str�ng str�ng)
	assert((s2 = s3) == s3);
	assert((s2 = s2) == s3);
	assert((s2 = ("foo")) == "foo");
	assert((s2 = "bar") == "bar");

	//-	operator+=(Str�ng str�ng) som tolkas som konkatenering.
	//foo, bar, bar
	(s2 += s1) += (s3 += s1);
	assert(s3 == "barfoo" && s2 == "barfoobarfoo" && s1 == "foo");

	//+= som f�r plats;
	s3 = "bar"; s3.reserve(10);
	s3 += s1;
	assert(s3 == "barfoo");

	//+= som inte f�r plats;
	s3 = "bar"; s3.reserve(5);
	s3 += s1;
	assert(s3 == "barfoo");

	//+= som f�r plats; Sj�lv
	s3 = "bar"; s3.reserve(10);
	s3 += s3;
	assert(s3 == "barbar");

	//+= som inte f�r plats; Sj�lv
	s3 = "bar"; s3.reserve(5);
	s3 += s3;
	assert(s3 == "barbar");

	//-	operator+ r�cker med bara String+String
	s2 = "bar";
	//auto sss=s1+s2;
	//sss=="foobar";
	//assert(sss=="foobar");
	////assert(s1+s2=="foobar" && s1=="foo");
	assert(s1 + s2 == "foobar" && s1 == "foo");

	//-	operator== r�cker med String==Str�ng
	//testas �verallt!

	//-	at(int i) som indexerar med range check
	try {
		s2.at(-1);
		assert(false);
	}
	catch (std::out_of_range&) {};
	try {
		s2.at(3);
		assert(false);
	}
	catch (std::out_of_range&) {};
	assert(s2.at(2) = 'r');

	//-	operator[](int i) som indexerar utan range check.
	s2[-1]; s2[1000];
	assert(s2[1] == 'a');

	//-	push_back(char c) l�gger till ett tecken sist.
	s2.push_back('a');
	assert(s2 == "bara");

	//-	length(), reserve(), capacity() och shrink_to_fit() �r funktioner som finns i container klasserna i STL.

	int len = s2.length();
	s2.shrink_to_fit();
	assert(s2.length() == s2.capacity());

	s2.getdata();
	if (s2.length() == s2.capacity()) {
		//lagrar str�ngen med \0
		const char * p1 = s2.getdata();
		s2.reserve(len); assert(p1 == s2.getdata()); //no change
		p1 = s2.getdata(); s2.reserve(len + 1); assert(p1 != s2.getdata()); //change
		p1 = s2.getdata(); s2.shrink_to_fit();  assert(p1 != s2.getdata()); //change
		p1 = s2.getdata(); s2.shrink_to_fit();  assert(p1 == s2.getdata()); //no change
	}
	else {
		//lagrar str�ngen utan \0
		int cap;
		s2.getdata(); cap = s2.capacity(); s2.shrink_to_fit(); assert(cap != s2.capacity()); //change
		cap = s2.capacity(); s2.getdata(); assert(cap != s2.capacity()); //change
		s2.shrink_to_fit(); cap = s2.capacity(); s2.reserve(len); assert(cap == s2.capacity()); //change
		s2.reserve(len + 1); assert(cap != s2.capacity()); //change
	}

	//-	const char* c_str()
	//tested above!

}

#define MACROTestIttPart(CR)							    \
	/*	*it, ++it, it++, (it+i), it[i], == och !=	*/	    \
	void TestIttPart##CR() {                                \
                                                            \
	String s1("foobar");								    \
for (auto i = s1.CR##begin(); i != s1.CR##end(); i++)	    \
	cout << *i;										        \
	cout << endl;										    \
if (#CR == "r" || #CR == "cr")						     	\
	s1 = "raboof";									        \
	auto it = s1.CR##begin();							    \
	assert(*it == 'f');									    \
	assert(*(it++) == 'f' && *it == 'o');					\
	++it;												    \
	assert(*++it == 'b');									\
	assert(*(it + 1) == 'a');								\
	assert(it[2] == 'r');									\
	}

MACROTestIttPart(,);	//, ger tomt argument
MACROTestIttPart(c);
MACROTestIttPart(r);
MACROTestIttPart(cr);


void TestF�rGodk�ntItt() {

	//-	typdefs f�r iterator, const_iterator,  reverse_iterator och const_revers_iterator
	String::iterator Str;
	String::const_iterator cStr;
	String::reverse_iterator rStr;
	String::const_reverse_iterator crStr;

	//-	funktionerna begin, end, cbegin, cend, rbegin, rend, crbegin och crend.

	//Iteratorerna ska kunna g�ra:
	//-	*it, ++it, it++, (it+i), it[i], == och !=
	TestIttPart();
	TestIttPartc();
	TestIttPartr();
	TestIttPartcr();


	//-	default constructor, copy constructor och tilldelning (=) 
	String s("foobar");
	Str = s.begin();
	cStr = s.cbegin();
	rStr = s.rbegin();
	crStr = s.crbegin();
	*Str = 'a';
	//	*(cStr+1)='b';	//Sak ge kompileringsfel!
	*(rStr + 2) = 'c';
	//	*(crStr+3)='d';	//Sak ge kompileringsfel!
	assert(s == "aoocar");

}

int main() {
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
	TestF�rGodk�ntString();
	TestF�rGodk�ntItt();
	String *lol = new String();
	std::cin >> lol;
	std::cout << lol;
	delete lol;
	cin.get();
}
