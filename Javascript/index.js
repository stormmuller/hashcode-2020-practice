let fs = require('fs');
let R = require('ramda');

const problems = {
  a: {
    problemFile: 'a_example.in',
    solutionFile: 'a_example.out'
  },
  b: {
    problemFile: 'b_small.in',
    solutionFile: 'b_small.out'
  },
  c: {
    problemFile: 'c_medium.in',
    solutionFile: 'c_medium.out'
  },
  d: {
    problemFile: 'd_quite_big.in',
    solutionFile: 'd_quite_big.out'
  },
  e: {
    problemFile: 'e_also_big.in',
    solutionFile: 'e_also_big.out'
  }
}

const currentlySolving = problems.e;
 
var contents = fs.readFileSync(currentlySolving.problemFile, 'utf8');

const firstRow = R.head(R.split('\n', contents));

const maximumPizzas = Number(R.head(R.split(' ', firstRow)));
const numberOfPizzaTypes = Number(R.split(' ', firstRow)[1]);

const secondRow = R.split('\n', contents)[1];

const pizzas = R.split(' ', secondRow);

const pizzasToOrder = [];
let sumOfPizzasOrdered = 0;

for(let i = numberOfPizzaTypes - 1 ; i >= 0 ; i--) {
  sumOfPizzasOrdered += Number(pizzas[i]);

  if(sumOfPizzasOrdered < maximumPizzas) {
    pizzasToOrder.push(i);
  } else {
    sumOfPizzasOrdered -= pizzas[i];
  }
}

const bob = pizzasToOrder.join(' ');

var file = fs.createWriteStream(currentlySolving.solutionFile);

file.on('error', function(err) { /* error handling */ });

file.write(pizzasToOrder.length + '\n');
file.write(bob);

file.end();