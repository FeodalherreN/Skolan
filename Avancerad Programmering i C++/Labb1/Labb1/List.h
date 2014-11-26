#pragma once
#include "Node.h"

typedef float T;

template <class T>
class List {
	friend class Node<T>;
private:
	Node<T> *last, *first;
public:
	Node<T> * push_front(T data);
	Node<T> * push_back(T data);
	T pop_front();
	T pop_back();
	Node<T> * First();
	Node<T> * Last();
	bool List::Check(int count);
	List() :first(nullptr), last(nullptr)
	{

	}
	~List()
	{
		if (first != nullptr)
		{
			Node<T> *temp = first->prev;
			while (temp != nullptr)
			{
				delete temp->next;
				temp = temp->prev;
			}
			delete last;
		}
	}
};
template <class T>
Node<T> * List<T>::push_front(T data)
{
	if (first == nullptr)
	{
		first = new Node<T>();
		first->data = data;
		last = first;
		return first;
	}
	else
	{
		first = first->InsertBefore(this, data);
		return first;
	}
}
template <class T>
Node<T> * List<T>::push_back(T data)
{
	if (last == nullptr)
	{
		last = new Node<T>();
		last->data = data;
		first = last;
		return last;
	}
	else
	{
		last = last->InsertAfter(this, data);
		return last;
	}
}
template <class T>
T List<T>::pop_front()
{
	if (first == nullptr)
	{
		return 0;
	}
	T data = first->data;
	if (first->prev != nullptr)
	{
	first = first->prev;
	delete first->next;
	first->next = nullptr;
	}
	else
	{
		first = nullptr;
		last = nullptr;
	}
	return data;
}

template <class T>
T List<T>::pop_back()
{
	if (last == nullptr)
	{
		return 0;
	}
	T data = last->data;
	if (last->next != nullptr)
	{
	last = last->next;
	delete last->prev;
	last->prev = nullptr;
	}
	else
	{
		last = nullptr;
		first = nullptr;
	}
	return data;
}
template <class T>
Node<T> * List<T>::First()
{
	return first;
}
template <class T>
Node<T> * List<T>::Last()
{
	return last;
}
template <class T>
bool List<T>::Check(int count) {
	//count anger hur många noder som förväntas i strukturen.
	//true betyder att allt var ok
	if ((count == 0) ^ (first == nullptr))
		return false; //tom lista ska ha first=null och tvärtom.
	if (first == nullptr)
		return (last == nullptr && count == 0);
	if ((last == nullptr) || count == 0)
		return false;
	//nu är first och last != null och count!=0)
	Node <T> * node = first;
	Node <T> * lastNode = nullptr;
	while (node != nullptr && count > 0) {
		if (lastNode != node->next)
			return false;
		count--;
		lastNode = node;
		node = node->prev;
	}
	return (lastNode == last) && count == 0;
}
