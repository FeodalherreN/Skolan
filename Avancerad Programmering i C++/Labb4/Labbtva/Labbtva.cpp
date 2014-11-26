// Labb2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include "RelOps.h"
#include "Rational.h"
#include "SharedPtr.h"

#include <iostream>
#include <cassert>
using namespace std;

typedef Rational<short> Rshort;
typedef Rational<int> Rint;
typedef Rational<long long> RLL;

struct C{
	float value;
	C(float value) :value(value){};
};


void TestFörGodkänt() {

	Rational<short> rs0, rs1(1), rs2(2, 1), rs3(3);
	Rational<int> ri0;
	Rational<long long> rll0, rll1(1), rll2(2, 1), rll3(3);


		//Konstrueras från ”Tal” dvs. Rtal rtal(tal);
 	RLL   rllx(1);
	RLL   rlly(rs0);
	
		//Jämföras med == dvs. if (rtal == tal) …
 		assert(rs1 == rs1);
 		assert(rs2 == 2);
	    assert(rs1 == rll1);

		//Tilldelas (=) från ”Tal” dvs. rtal=tal;
      	rs3 = Rint(13, 3);
		assert(rs3 == Rshort(13, 3));
		rs3 = rll3 = -17;
		assert(rs3 == Rshort(-17));

		//+= med ”Tal” dvs. rtal += tal;
		assert((rs3 += 4) == Rshort(-13));

		//+  dvs. (rtal + tal)
        rs3 = Rshort(13, 3);
		assert(rs3 + rll2 == Rshort(19, 3));
		assert(rs3 + 2 == Rshort(19, 3));

		//unärt ”–” dvs. rtal1 = -rtal2;
		assert((rs0 = -rs1) == Rshort(-1));

		//båda ++ operatorerna, dvs. ++rtal; rtal++;
		rll3 = RLL(1, 6);
		assert(++rll3 == RLL(7, 6));
		assert(rll3++ == RLL(7, 6));
		assert(rll3 == RLL(13, 6));

		// explicit konvertering till Tal. (Kräver VS2012 och kompilator CTP november 12.
		int i = static_cast<int>(rll3);
		assert(i == 2);

		// Overloading av << och >> (ut och in matning)
		std::cout << "Utmatning>" << rs3 << "< skriv in texten mellan > och < + retur\n";
		std::cin >> rs2;
		assert(rs3 == rs2);
}
void TestG() {
	//-	Konstruktor som tar:	
	//	o	inget	G
	//	o	En SharedPtr	G
	//	o	En pekare	G

	SharedPtr<C> p11;
	assert(!p11);
	SharedPtr<C> p15(nullptr);
	assert(!p15);
	SharedPtr<C> p12(new C(12));
	assert(p12);
	SharedPtr<C> p13(p11);
	assert(!p13);

	assert(p12.unique());
	SharedPtr<C> p14(p12);
	assert(p14);
	assert(!p12.unique());

	//-	Destruktor	G
	//It will test itself
	//-	Tilldelning från en	
	//	o	En SharedPtr	G
	p14 = p12;
	assert(p14);

	p14 = p14;
	assert(p14);

	//-	Jämförelse med (== och <)
	SharedPtr<C> p31(new C(31));
	//	o	En SharedPtr	G
	assert(p11 == nullptr);
	assert(p11 < p12);
	assert(!(p12 < p11));
	assert(p14 == p12);
	assert(!(p14 == p31));
	assert((p14 < p31) || (p31 < p14));

	//get, * och ->

	SharedPtr<C> p41(new C(41));
	SharedPtr<C> p42(new C(42));
	assert((p41->value) == (p41.get()->value));
	assert((p41->value) != (p42.get()->value));
	assert(&(*p41) == (p41.get()));

	p41.reset();
	assert(!p41);
}
int main() {
	//TestFörGodkänt();
	TestG();
	int i = _CrtDumpMemoryLeaks();
}
