#pragma once
template <class T>
class List;

template <class T>
class Node {
	friend class List<T>;
private:
	Node *prev, *next;
public:
	T data;
	Node * Prev();
	Node * Next();
	Node * InsertAfter(List<T> * list, T data);
	Node * InsertBefore(List<T> * list, T data);
	Node() :prev(nullptr), next(nullptr){}
	~Node()
	{
	}
};

    template <class T>
	Node<T> * Node<T>::Prev()
	{
		return prev;
	}
	template <class T>
	Node<T> * Node<T>::Next()
	{
		return next;
	}
	template <class T>
	Node<T> * Node<T>::InsertAfter(List<T> * list, T data)
	{
		Node<T> *newNode = new Node<T>();
		newNode->data = data;
		if (this->prev != nullptr)
		{
			prev->next = newNode;
			newNode->prev = prev;
			this->prev = newNode;
			newNode->next = this;
		}
		else
		{
			newNode->next = this;
			newNode->prev = nullptr;
			this->prev = newNode;
		}
		return newNode;
	}
	template <class T>
	Node<T> * Node<T>::InsertBefore(List<T> * list, T data)
	{
		Node<T> *newNode = new Node<T>();
		newNode->data = data;
		if (this->next != nullptr)
		{
			next->prev = newNode;
			newNode->next = next;
			this->next = newNode;
			newNode->prev = this;
		}
		else
		{
			next = newNode;
			newNode->prev = this;
			newNode->next = nullptr;
		}
		return newNode;
	}
	
