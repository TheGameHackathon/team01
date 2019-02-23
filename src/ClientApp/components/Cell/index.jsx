import React from 'react';
import styles from './styles.css';

export default class Cell extends React.Component {
    constructor(props) {
        super(props);
        this.state = { x: this.props.x, y: this.props.y };
    }


    render () {
        return (
            <div className={styles.root} />
        );
    }
}
