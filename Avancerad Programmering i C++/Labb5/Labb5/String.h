#include <vector>
#include "StringIterator.h"
#include <iostream>
#include <sstream>
using namespace std;
class String
{
protected:
	char* data;
	int datasize;
	int datalength;

public:
	typedef Iterator iterator;
	typedef Const_Iterator const_iterator;
	typedef Reverse_Iterator reverse_iterator;
	typedef Const_Reverse_Iterator const_reverse_iterator;
	String()
	{
		datalength = 0;
		datasize = 0;
		data = createNulledArray(datasize);
	}
	String(const char* cstr)
	{
		int i = strlen(cstr);
		data = new char[i + 33];
		memcpy(data, cstr, sizeof(*data) *  i + 1);
		datasize = i + 33;
		datalength = i;
	}
	String(const String& inString)
	{
		data = new char[inString.datasize];
		memcpy(data, inString.data, sizeof(*data) * inString.datalength+1);
		datasize = inString.datasize;
		datalength = inString.datalength;
	}
	~String()
	{
		if (data != nullptr)
			delete data;
	}
	friend ostream& operator<<(ostream& out, const String* x){
		out << x->data << endl;
		return out;
	}
	friend istream& operator >>(istream & IS, String* S)
	{
		char* input = new char[100];
		IS.getline(input, 100);

		int i = 0;
		while (input[i] != '\0')
		{
			i++;
		}
		S->datalength = i + 1;
		delete[]S->data;
		S->data = new char[(i + 1)];
		for (int j = 0; j < (i); j++)
		{
			S->data[j] = input[j];
		}
		S->data[i] = '\0';
		delete[]input;
		return IS;
	}
	char* createNulledArray(int piSize)
	{
		char *outArr = new char[piSize];
		for (int i = 0; i < piSize; i++)
		{
			outArr[i] = 0;
		}
		return outArr;
	}
	String& operator=(const String& rhs)
	{
		if (data != rhs.data)
		{
			delete[] data;
			data = new char[rhs.datasize];
			memcpy(data, rhs.data, rhs.datasize);
			datasize = rhs.datasize;
			datalength = rhs.datalength;
		}
			return *this;
	}
	String& operator=(const char* cstr)
	{
		delete[] data;
		int i = strlen(cstr);
		data = new char[i + 33];
		memcpy(data, cstr, i + 1);
		datasize = i + 32;
		datalength = i;
		return *this;
	}
	String& operator=(char ch)
	{
		delete[] data;
		data = new char[34];
		data[0] = ch;
		data[1] = 0;
		datasize = 34;
		datalength = 1;
		return *this;
	}
	friend bool operator==(const String&
		lhs, const String& rhs)
	{
		if (lhs.datalength != rhs.datalength)
			return false;
		for (int i = 0; i < rhs.datalength; i++)
		{
			if (lhs.data[i] != rhs.data[i])
				return false;
		}
		return true;
	}
	String& operator+=(const String& rhs)
	{
		if (datalength + rhs.datalength < datasize)
		{
			memcpy(data + datalength, rhs.data, rhs.datalength);
			datalength += rhs.datalength;
			data[datalength] = '\0';
		}
		else
		{
			char* temp = new char[datasize + rhs.datalength << 1];
			memcpy(temp, data, datasize);
			delete[] data;
			data = temp;
			memcpy(data + datalength, rhs.data, rhs.datalength);
			datasize += rhs.datalength << 1;
			datalength += rhs.datalength;
			data[datalength + 1] = '\0';
		}
		return *this;
	}
	String& operator+=(char* cstr)
	{
		int l = strlen(cstr);
		if (datalength + l < datasize)
		{
			memcpy(data + datalength, cstr, l);
			datalength += l;
			data[datalength + 1] = '\0';
		}
		else
		{
			char* temp = new char[datasize + l << 1];
			memcpy(temp, data, datasize);
			delete[] data;
			data = temp;
			memcpy(data + datalength, cstr, l);
			datasize += l << 1;
			datalength += l;
			data[datalength + 1] = '\0';
		}
		return *this;
	}
	String operator+(String& rhs)
	{
		String tempString(*this);
		tempString += rhs;
		return tempString;
	}
	char& at(int i)
	{
		if (i > datalength - 1 || i < 0)
		{
			throw std::out_of_range("false");
		}
		else
			return data[i];
	}
	char& operator[](int i)
	{
		return data[i];
	}
	const char* getdata() const
	{
		return this->data;
	}
	int length() const
	{
		return datalength;
	}
	void reserve(int newSize)
	{
		if (this->datalength <= newSize && this->datasize != newSize)
		{	// change reservation
			datasize = newSize;
			char* newArr = createNulledArray(datasize);
			for (int i = 0; i < datalength; i++)
				newArr[i] = data[i];
			delete data;
			data = newArr;
		}
	}
	int capacity() const
	{
		return datasize;
	}
	void shrink_to_fit()
	{
		if (datasize != datalength){
			datasize = datalength;
			char* newArr = createNulledArray(datasize + 1);//+1 för att det ska finna plats för en nullchar i slutet
			for (int i = 0; i < datalength; i++)
				newArr[i] = data[i];
			if (data)
				delete data;
			data = newArr;
		}
	}
	void push_back(char piChar)
	{
		data[datalength] = piChar;
		data[datalength + 1] = '\0';
		datalength = datalength + 1;
	}
	iterator begin()
	{
		iterator it(data);
		return it;
	}
	iterator end()
	{
		iterator it(data + datalength);
		return it;
	}
	const_iterator cbegin()
	{
		const_iterator it(data);
		return it;
	}
	const_iterator cend()
	{
		const_iterator it(data + datalength);
		return it;
	}
	reverse_iterator rbegin()
	{
		reverse_iterator it(data + datalength -1);
		return it;
	}
	reverse_iterator rend()
	{
		reverse_iterator it(data -1);
		return it;
	}
	const_reverse_iterator crbegin()
	{
		const_reverse_iterator it(data + datalength - 1);
		return it;
	}
	const_reverse_iterator crend()
	{
		const_reverse_iterator it(data - 1);
		return it;
	}
};