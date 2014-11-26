// Labb3.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
#include <vector>
#include <algorithm>
#include "C.h"
#include <string>
#include <iostream>
#include <sstream>
#include <time.h>

using namespace std;

bool isEven(C<10> i) { return (((int)i.value % 2) != 1); };
void UppgiftEtt()
{
	vector<C<10>> container;
	int size = 5;
	cout << "Ny lista med random nummer....";
	cout << "\n";
	for (int i = 0; i < size; i++)
	{
		int nr = rand() % 100 + 1;
		C<10> L;
		L.value = (float)nr;
		container.push_back(L);
		cout << L.value;
		cout << "\n";
	}
	cout << "Tar bort jämna tal......";
	cout << "\n";
	for (int i = 0; i < (int)container.size(); i++)
	{
		container.erase(remove_if(container.begin(), container.end(), isEven), container.end());
	}
	cout << "Nya listan utan jämna tal.....";
	cout << "\n";
	for (int i = 0; i < (int)container.size(); i++)
	{
		cout << container[i].value;
		cout << "\n";
	}
};
template <class ForwardIterator>
void ForwardSort(ForwardIterator begin, ForwardIterator end)
{
	bool sorted = false;
	int size = end - begin;
	while (!sorted)
	{
		if (size < 2)
			break;
		sorted = true;
		vector<C<10>>::iterator iter = begin;
		vector<C<10>>::iterator iter_prev = begin;
		iter++;

		while (iter != end)
		{
				if ((*iter).value < (*iter_prev).value)
				{
					sorted = false;
				    C<10>temp = (*iter);
					(*iter) = (*iter_prev);
					(*iter_prev) = temp;
				}
				iter++;
				iter_prev++;
		}
	}
}
void UppgiftTva()
{
	vector<C<10>> container;
	int size = 6;
	for (int i = 0; i < size; i++)
	{
		int nr = rand() % 100 + 1;
		C<10> L;
		L.value = (float)nr;
		container.push_back(L);
	}
	ForwardSort(container.begin(), container.end());
	for (int i = 0; i < (int)container.size(); i++)
	{
		cout << container[i].value;
		cout << "\n";
	}
}
template <class ReverseIterator>
void ReverseSort(ReverseIterator begin, ReverseIterator end)
{
	bool sorted = false;
	int size = end - begin;
	while (!sorted)
	{
		if (size < 2)
			break;
		sorted = true;
		vector<C<10>>::reverse_iterator iter = begin;
		vector<C<10>>::reverse_iterator iter_prev = begin;
		iter++;

		while (iter != end)
		{
			if ((*iter).value < (*iter_prev).value)
			{
				sorted = false;
				C<10>temp = (*iter);
				(*iter) = (*iter_prev);
				(*iter_prev) = temp;
			}
			iter++;
			iter_prev++;
		}
	}
}
void UppgiftTre()
{
	cout << "TreA";
	cout << "\n";
	vector<C<10>> container;
	int size = 6;
	for (int i = 0; i < size; i++)
	{
		int nr = rand() % 100 + 1;
		C<10> L;
		L.value = (float)nr;
		container.push_back(L);
		cout << L.value;
		cout << "\n";
	}
	cout << "Sorting...\n";
	ReverseSort(container.rbegin(), container.rend());
	for (int i = 0; i < (int)container.size(); i++)
	{
		cout << container[i].value;
		cout << "\n";
	}
	cout << "TreB";
	cout << "\n";
	container.clear();
	for (int i = 0; i < size; i++)
	{
		int nr = rand() % 100 + 1;
		C<10> L;
		L.value = (float)nr;
		container.push_back(L);
	}
	for (int i = 0; i < (int)container.size(); i++)
	{
		cout << container[i].value;
		cout << "\n";
	}
	cout << "Sorting with lambda...";
	sort(container.begin(), container.end(),
		[](const C<10> & a, const C<10> & b) -> bool
	{
		return a.value < b.value;
	});
	for (int i = 0; i < (int)container.size(); i++)
	{
		cout << container[i].value;
		cout << "\n";
	}
}
void UppgiftFyra()
{
	cout << "Uppgift Fyra";
	cout << "\n";
	vector<C<10>*> pointercontainer;
	int size = 6;
	for (int i = 0; i < size; i++)
	{
		int nr = rand() % 100 + 1;
		C<10> *L = new C<10>();
		L->value = (float)nr;
		pointercontainer.push_back(L);
	}
	for (int i = 0; i < (int)pointercontainer.size(); i++)
	{
		cout << pointercontainer[i]->value;
		cout << "\n";
	}
	cout << "Sorting with lambda...";
	sort(pointercontainer.begin(), pointercontainer.end(),
		[](const C<10>* a, const C<10>* b) -> bool
	{
		return a->value < b->value;
	});
	for (int i = 0; i < (int)pointercontainer.size(); i++)
	{
		cout << pointercontainer[i]->value;
		cout << "\n";
	}
	for (int i = 0; i < (int)pointercontainer.size(); i++)
	{
		delete pointercontainer[i];
	}
}
int _tmain(int argc, _TCHAR* argv[])
{
	srand((int)time(0));
	//UppgiftEtt();
	//UppgiftTva();
	//UppgiftTre();
	UppgiftFyra();
	return 0;
}