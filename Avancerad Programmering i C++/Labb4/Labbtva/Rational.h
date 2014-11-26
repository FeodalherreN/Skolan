#include <iostream>
#include "GCD.h"
#include <sstream>
#include <string>

template<typename Tint>
class Rational {
public:
	Tint P, Q;
	friend std::ostream& operator<< (std::ostream & cout, Rational<Tint> R){
		cout << R.P << '/' << R.Q;
		return cout;
	}
	friend std::istream& operator>> (std::istream &in, Rational &rat) 
	{ 
		std::string Input;
		Tint firstnumber;
		Tint secondnumber;
		std::string firstnumberasstring = "";
		std::string secondnumberasstring = "";
		getline(in, Input);
		int NrOfChars = Input.size();
		bool nextnumber = false;
		for (int i = 0; i <= NrOfChars; i++)
		{
			if (!nextnumber)
			{
				if (Input[i] == '/')
				{
					stringstream convert(firstnumberasstring);
					if (!(convert >> firstnumber))
						firstnumber = 0;
					nextnumber = true;
				}
				else
				{
					firstnumberasstring += Input[i];
				}
			}
			else
			{
				secondnumberasstring += Input[i];
			}
		}
		stringstream convert(secondnumberasstring);
		if (!(convert >> secondnumber))
			secondnumber = 0;
		rat.P = firstnumber;
		rat.Q = secondnumber;
		return in; 
	}
	Rational() : P(0), Q(1) {};
	Rational(Tint P) :P(P), Q(1) {};
	Rational(Tint P, Tint Q) :P(P), Q(Q) {
		Reduce(P, Q);
	}
	//Rational(const Rational<Tint>& T) : P(T.P), Q(T.Q) {};
	Rational(const Rational<short>& S) : P(S.P), Q(S.Q) {};
	Rational(const Rational<long long>& LL) : P(LL.P), Q(LL.Q) {};
 	Rational(const Rational<int>& I) : P(I.P), Q(I.Q) {};

	Rational operator+(const Rational rhs) const {
		Tint tempP = rhs.Q*P + Q*rhs.P;
		Tint tempQ = Q*rhs.Q;
		return Rational(tempP, tempQ);
	}
	Rational operator-(const Rational rhs) const {
		Tint tempP = rhs.Q*P - Q*rhs.P;
		Tint tempQ = Q*rhs.Q;
		return Rational(tempP, tempQ);
	}
	Rational operator-() const {
		return Rational(this->P*-1, this->Q);
	}
	bool operator==(const Rational rhs){
		if (this->P == rhs.P && this->Q == rhs.Q)
		{
			return true;
		}
		else
			return false;
	}
	Rational operator++()
	{
		this->P = this->P + Q;
		return Rational(P, Q);
	}
	Rational operator++(int)
	{
		Rational tmp(*this);
		operator++();
		return tmp;
	}
	Rational operator+=(const Rational rhs)
	{
		return *this + rhs;
	}
	Rational operator!=(const Rational rhs)
	{
		return !(rhs.P == rhs.Q);
	}
	Rational operator>(const Rational rhs) 
	{ 
		return (rhs.Q<rhs.P); 
	}
	Rational operator>=(const Rational rhs) 
	{ 
		return !(rhs.Q<rhs.P); 
	}
	Rational operator <=(const Rational rhs) {
		return !(rhs.Q<rhs.P); 
	}
	explicit operator int()
	{
		int result = this->P / this->Q;
		return result;
	}
};