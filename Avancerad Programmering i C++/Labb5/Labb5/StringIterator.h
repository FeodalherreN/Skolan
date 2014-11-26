#define _CRTDBG_MAP_ALLOC
#ifdef _DEBUG
#ifndef DBG_NEW
#define DBG_NEW new ( _NORMAL_BLOCK , __FILE__ , __LINE__ )
#define new DBG_NEW
#endif
#endif  // _DEBUG
class Iterator
{
private:
	char* data;
public:
	Iterator(){}
	Iterator(char* inData) : data(inData){}
	char& operator*() { return *data; }
	Iterator& operator=(char* rhs){ data = rhs; return *this; }
	Iterator& operator=(Iterator& rhs){ data = rhs.data; return *this; }
	Iterator& operator++(int junk) { Iterator i = *this; data++; return i; }
	Iterator& operator++() { data++; return *this; }
	char* operator+(int rhs){ return data + rhs; }
	char& operator[](int index){ return data[index];}
	char* operator->() { return data; }
	bool operator==(const Iterator& rhs) { return data == rhs.data; }
	bool operator!=(const Iterator& rhs) { return data != rhs.data; }
};

class Const_Iterator
{
private:
	char* data;
public:
	Const_Iterator(){}
	Const_Iterator(char* inData) : data(inData) {}
	Const_Iterator& operator=(char* rhs){ data = rhs; return *this; }
	Const_Iterator& operator=(Const_Iterator& rhs){ data = rhs.data; return *this; }
	Const_Iterator& operator++(int junk) { Const_Iterator i = *this; data++; return i; }
	Const_Iterator& operator++() { data++; return *this; }
	const char* operator+(const int rhs){ return data + rhs; }
	const char& operator[](const int index){ return data[index]; }
	const char& operator*() { return *data; }
	const char* operator->() { return data; }
	const bool operator==(const Const_Iterator& rhs) { return data == rhs.data; }
	const bool operator!=(const Const_Iterator& rhs) { return data != rhs.data; }
};

class Reverse_Iterator
{
private:
	char* data;
public:
	Reverse_Iterator(){}
	Reverse_Iterator(char* inData) : data(inData){}
	char& operator*() { return *data; }
	Reverse_Iterator& operator=(char* rhs){ data = rhs; return *this; }
	Reverse_Iterator& operator=(Reverse_Iterator& rhs){ data = rhs.data; return *this; }
	Reverse_Iterator& operator++(int junk) { Reverse_Iterator i = *this; data--; return i; }
	Reverse_Iterator& operator++() { data--; return *this; }
	char* operator+(int rhs){ return data - rhs; }
	char& operator[](int index){ return *(data - index); }
	char* operator->() { return data; }
	bool operator==(const Reverse_Iterator& rhs) { return data == rhs.data; }
	bool operator!=(const Reverse_Iterator& rhs) { return data != rhs.data; }
};

class Const_Reverse_Iterator
{
private:
	char* data;
public:
	Const_Reverse_Iterator(){}
	Const_Reverse_Iterator(char* inData) : data(inData) {}
	//Const_Iterator& operator=(char* rhs){ data = rhs; return *this; }
	//Const_Iterator& operator=(Const_Iterator& rhs){ data = rhs.data; return *this; }
	Const_Reverse_Iterator& operator++(int junk) { Const_Reverse_Iterator i = *this; data--; return i; }
	Const_Reverse_Iterator& operator++() { data--; return *this; }
	const char* operator+(const int rhs){ return data - rhs; }
	const char& operator*() { return *data; }
	const char* operator->() { return data; }
	const char& operator[](const int index){ return *(data - index); }
	const bool operator==(const Const_Reverse_Iterator& rhs) { return data == rhs.data; }
	const bool operator!=(const Const_Reverse_Iterator& rhs) { return data != rhs.data; }
};