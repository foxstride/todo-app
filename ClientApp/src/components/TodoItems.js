import React, { Component } from 'react';

export class TodoItems extends Component {
  static displayName = TodoItems.name;

  constructor(props) {
    super(props);
    this.state = { todoItems: [], loading: true };
  }

  componentDidMount() {
    this.populateTodoItems();
  }

  getTodoItems(todoItems) {
    return (
      <div>
      <h1>Test</h1>
      {todoItems.map(todoItem => 
        <div className="card" key={todoItem.id}>
          <div className="card-body">
            <h5 className="card-title">{todoItem.title}</h5>
            <p className="card-text">{todoItem.description}</p>
            {todoItem.finished ? 
            <button className="btn btn-success" disabled>Finished!</button> :
            <button onClick={(event) => this.finishTodoItem(todoItem, event)} className="btn btn-primary">Finish</button>}
          </div>
        </div>
      )}
      </div>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : this.getTodoItems(this.state.todoItems);

    return (
      <div>
        <h1 id="tableLabel">Todo Items</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateTodoItems() {
    const response = await fetch('todo');
    const data = await response.json();
    console.log(data);
    this.setState({ todoItems: data.todoItems, loading: false });
  }

  async finishTodoItem(todoItem, event) {
    if (todoItem.id) {
      todoItem.finished = true;
      const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(todoItem)
      };
      var response = await fetch(`todo/${todoItem.id}`, requestOptions);
      if (response.ok) {
        console.log(`Successfully updated todo item: ${todoItem.id}`);
        event.target.classList.add('btn-success');
        event.target.classList.remove('btn-primary');
        event.target.setAttribute('disabled', '');
        event.target.textContent = 'Finished!';
      }
    } else {
      console.warn('Tried to finish a todo without an id');
    }
  }
}
