import React from 'react';

import { RiGraduationCapFill, RiBookOpenFill } from '@remixicon/react';

type Props = {
  role: 'STUDENT' | 'LECTURER';
  selectedRole: number;
  handleClick: () => void;
};

const RoleSelection = ({ role, selectedRole, handleClick }: Props) => {
  const style = `w-full flex items-center justify-start gap-3 rounded-lg ${role === 'STUDENT' ? 'border-primary/20 bg-primary/5 hover:bg-primary/10' : 'border-green-500/20 bg-green-50 hover:bg-green-100'} p-5 cursor-pointer h-24`;
  const isStudent = role === 'STUDENT';

  return (
    <button className={style} onClick={handleClick}>
      {isStudent ? (
        <RiGraduationCapFill className='h-5 w-5 text-primary' />
      ) : (
        <RiBookOpenFill className='h-5 w-5 text-green-600' />
      )}

      <div className='text-left'>
        <div className='font-semibold'>
          {isStudent ? 'Student' : 'Lecturer'}
        </div>
        <div className='text-sm text-muted-foreground'>
          {isStudent
            ? 'Access your courses, assignments and grades'
            : 'Manage courses, students and academic records'}
        </div>
      </div>
    </button>
  );
};

export default RoleSelection;
